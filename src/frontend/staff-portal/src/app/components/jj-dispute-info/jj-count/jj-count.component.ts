import { Component, EventEmitter, Input, Output, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { UtilsService } from '@core/services/utils.service';
import { MockConfigService } from 'tests/mocks/mock-config.service';
import { JJDisputeService } from '../../../services/jj-dispute.service';
import { JJDispute, JJDisputedCount } from 'app/api';
import { MatRadioChange } from '@angular/material/radio';
import { DialogOptions } from '@shared/dialogs/dialog-options.model';
import { MoreOptionsDialogComponent } from '@shared/dialogs/more-options-dialog/more-options-dialog.component';


@Component({
  selector: 'app-jj-count',
  templateUrl: './jj-count.component.html',
  styleUrls: ['./jj-count.component.scss']
})
export class JJCountComponent implements OnInit {
  @Input() public jjDisputeInfo: JJDispute;
  @Input() public count: number;
  @Input() public type: string;
  @Input() public jjDisputedCount: JJDisputedCount;
  @Output() public jjDisputedCountUpdate: EventEmitter<JJDisputedCount> = new EventEmitter<JJDisputedCount>();
  public isMobile: boolean;
  public todayDate: Date = new Date();
  public violationDate: string = "";
  public form: FormGroup;
  public timeToPay: string = "no";
  public fineReduction: string = "no";
  public inclSurcharge: string = "yes";
  public lesserOrGreaterAmount: number = 0;
  public surcharge: number = 0;

  constructor(
    protected route: ActivatedRoute,
    private dialog: MatDialog,
    private utilsService: UtilsService,
    public mockConfigService: MockConfigService,
    public jjDisputeService: JJDisputeService,
    protected formBuilder: FormBuilder,
  ) {
    const today = new Date();
    this.isMobile = this.utilsService.isMobile();
  }

  ngOnInit(): void {
    if (this.jjDisputedCount) this.violationDate = this.jjDisputeInfo.violationDate.split("T")[0];

    this.form = this.formBuilder.group({
      totalFineAmount: [null, [Validators.required, Validators.max(9999.99), Validators.min(0.00)]],
      lesserOrGreaterAmount: [null, [Validators.required, Validators.max(9999.99), Validators.min(0.00)]],
      revisedDueDate: [null, [Validators.required]],
      comments: [{ value: null, disabled: !this.jjDisputedCount }]
    });

    // initialize if no value
    if (this.jjDisputedCount) {
      if (this.jjDisputedCount.totalFineAmount) {
        this.surcharge = this.jjDisputedCount.totalFineAmount / 1.15 * 0.15;
      } else {
        this.jjDisputedCount.totalFineAmount = this.jjDisputedCount.ticketedFineAmount;
      }
      if (!this.jjDisputedCount.revisedDueDate) this.jjDisputedCount.revisedDueDate = this.jjDisputedCount.dueDate;

      // initialize form, radio buttons
      this.form.patchValue(this.jjDisputedCount);
      this.inclSurcharge = this.jjDisputedCount.includesSurcharge == true ? "yes" : "no";
      this.fineReduction = this.jjDisputedCount.totalFineAmount != this.jjDisputedCount.ticketedFineAmount ? "yes" : "no";
      this.timeToPay = this.jjDisputedCount.dueDate != this.jjDisputedCount.revisedDueDate ? "yes" : "no";

      // listen for form changes
      this.form.valueChanges.subscribe(() => {
        this.jjDisputedCount.comments = this.form.get('comments').value;
        this.jjDisputedCount.revisedDueDate = this.form.get('revisedDueDate').value;
        this.jjDisputedCount.lesserOrGreaterAmount = this.form.get('lesserOrGreaterAmount').value;
        this.jjDisputedCount.totalFineAmount = this.form.get('totalFineAmount').value;
        this.jjDisputedCount.includesSurcharge = this.inclSurcharge == "yes" ? true : false;
        this.jjDisputedCountUpdate.emit(this.jjDisputedCount);
      });
    }
  }

  onMoreOptions() {
    const data: DialogOptions = {
      titleKey: "Response to Written Reasons Dispute",
      messageKey: "",
      actionTextKey: "Require court hearing",
      actionType: "warn",
      cancelTextKey: "Go back",
      icon: "error_outline",
    };
    this.dialog.open(MoreOptionsDialogComponent, { data, width: "50%" }).afterClosed()
      .subscribe((action: any) => {
        if (action) {
          // TODO: fill in to do actions depending on choice
        }
      });
  }

  onChangelesserOrGreaterAmount() {
    // surcharge is always 15%
    if (this.inclSurcharge == "yes") {
      this.form.get('totalFineAmount').setValue(this.form.get('lesserOrGreaterAmount').value);
      this.lesserOrGreaterAmount = this.form.get('lesserOrGreaterAmount').value / 1.15;
      this.surcharge = 0.15 * this.lesserOrGreaterAmount;
    } else {
      this.form.get('totalFineAmount').setValue(this.form.get('lesserOrGreaterAmount').value * 1.15);
      this.lesserOrGreaterAmount = this.form.get('lesserOrGreaterAmount').value;
      this.surcharge = this.form.get('lesserOrGreaterAmount').value * 0.15;
    }
  }

  updateFineAmount(event: MatRadioChange) {
    // if they select no set it back to ticketed Amount
    // do nothing if yes
    if (event.value == "no") {
      this.form.get('totalFineAmount').setValue(this.jjDisputedCount.ticketedFineAmount);
    }
  }

  updateInclSurcharge(event: MatRadioChange) {
    // surcharge is always 15%
    if (event.value == "yes") {
      this.form.get('totalFineAmount').setValue(this.form.get('lesserOrGreaterAmount').value);
      this.lesserOrGreaterAmount = this.form.get('lesserOrGreaterAmount').value / 1.15;
      this.surcharge = 0.15 * this.lesserOrGreaterAmount;
    } else {
      this.form.get('totalFineAmount').setValue(this.form.get('lesserOrGreaterAmount').value * 1.15);
      this.lesserOrGreaterAmount = this.form.get('lesserOrGreaterAmount').value;
      this.surcharge = this.form.get('lesserOrGreaterAmount').value * 0.15;
    }
  }

  updateRevisedDueDate(event: MatRadioChange) {
    // if they select no set it back to passed in due date
    if (event.value == "no") {
      this.form.get('revisedDueDate').setValue(this.jjDisputedCount.dueDate);
    }
  }
}

