import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControlValidators } from '@core/validators/form-control.validators';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { LoggerService } from '@core/services/logger.service';
import { UtilsService } from '@core/services/utils.service';
import { CountryCodeValue, ProvinceCodeValue } from '@config/config.service';
import { ConfigService } from '@config/config.service';
import { Dispute, DisputeService } from '../../../services/dispute.service';
import { Subscription } from 'rxjs';
import { DialogOptions } from '@shared/dialogs/dialog-options.model';
import { ConfirmReasonDialogComponent } from '@shared/dialogs/confirm-reason-dialog/confirm-reason-dialog.component';
import { ConfirmDialogComponent } from '@shared/dialogs/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-contact-info',
  templateUrl: './contact-info.component.html',
  styleUrls: ['./contact-info.component.scss', '../../../app.component.scss']
})
export class ContactInfoComponent implements OnInit {
  @Input() public disputeInfo: Dispute;
  @Output() public backInbox: EventEmitter<any> = new EventEmitter();
  public isMobile: boolean;
  public provinces: ProvinceCodeValue[];
  public states: ProvinceCodeValue[];
  public bcFound: ProvinceCodeValue[] = [];
  public canadaFound: CountryCodeValue[] = [];
  public usaFound: CountryCodeValue[] = [];
  public busy: Subscription;
  public initialDisputeValues: Dispute;
  public todayDate: Date = new Date();
  public lastUpdatedDispute: Dispute;
  public retrieving: boolean = true;
  public violationDate: string = "";
  public violationTime: string = "";
  public conflict: boolean = false;
  public form: FormGroup;
  public collapseObj: any = {
    contactInformation: true
  }

  constructor(
    protected route: ActivatedRoute,
    protected formBuilder: FormBuilder,
    private dialog: MatDialog,
    private utilsService: UtilsService,
    public config: ConfigService,
    private disputeService: DisputeService,
    private logger: LoggerService,
  ) {
    const today = new Date();
    this.isMobile = this.utilsService.isMobile();

    this.bcFound = this.config.provincesAndStates.filter(x => x.provAbbreviationCd === "BC");
    this.canadaFound = this.config.countries.filter(x => x.ctryLongNm === "Canada");
    this.usaFound = this.config.countries.filter(x => x.ctryLongNm === "USA");
    this.provinces = this.config.provincesAndStates.filter(x => x.ctryId === this.canadaFound[0]?.ctryId && x.provSeqNo !== this.bcFound[0]?.provSeqNo);  // skip BC it will be manually at top of list
    this.states = this.config.provincesAndStates.filter(x => x.ctryId === this.usaFound[0]?.ctryId); // USA only
  }

  public ngOnInit() {
    this.form = this.formBuilder.group({
      ticketNumber: [null, [Validators.required]],
      homePhoneNumber: [null, [Validators.required, Validators.maxLength(20)]],
      emailAddress: [null, [Validators.email]],
      disputantSurname: [null, [Validators.required]],
      disputantGivenNames: [null, [Validators.required]],
      disputantBirthdate: [null, [Validators.required]],
      address: [null, [Validators.required, Validators.maxLength(300)]],
      addressCity: [null, [Validators.required]],
      addressProvince: [null, [Validators.required, Validators.maxLength(30)]],
      addressProvinceProvId: [null],
      addressProvinceCountryId: [null],
      addressProvinceSeqNo: [null],
      addressCountryId: [null, [Validators.required]],
      rejectedReason: [null, Validators.maxLength(256)], // Optional
      postalCode: [null, [Validators.required, Validators.maxLength(6), Validators.minLength(6)]],
      driversLicenceNumber: [null, [Validators.required, Validators.minLength(7), Validators.maxLength(9)]],
      driversLicenceProvince: [null, [Validators.required, Validators.maxLength(30)]],
      driversLicenceProvinceProvId: [null],
      driversLicenceCountryId: [null],
      driversLicenceProvinceSeqNo: [null],
    });
    this.getDispute();
  }

  public onCountryChange(ctryId: number) {
    setTimeout(() => {
      this.form.get('postalCode').setValidators([Validators.maxLength(6)]);
      this.form.get('addressProvince').setValidators([Validators.maxLength(30)]);
      this.form.get('addressProvince').setValue(null);
      this.form.get('addressProvinceSeqNo').setValidators(null);
      this.form.get('addressProvinceSeqNo').setValue(null);
      this.form.get('addressProvinceCountryId').setValue(ctryId);
      this.form.get('addressProvinceProvId').setValue(null);
      this.form.get('homePhoneNumber').setValidators([Validators.maxLength(20)]);
      this.form.get('driversLicenceProvince').setValidators([Validators.maxLength(30)]);
      this.form.get("driversLicenceProvince").setValue(null);
      this.form.get("driversLicenceProvinceSeqNo").setValidators(null);
      this.form.get("driversLicenceProvinceSeqNo").setValue(null);
      this.form.get("driversLicenceProvinceProvId").setValue(null);
      this.form.get("driversLicenceCountryId").setValue(ctryId);

      if (ctryId === this.canadaFound[0]?.ctryId || ctryId === this.usaFound[0]?.ctryId) {
        this.form.get('addressProvinceSeqNo').addValidators([Validators.required]);
        this.form.get('postalCode').addValidators([Validators.required]);
        this.form.get('homePhoneNumber').addValidators([Validators.required, FormControlValidators.phone]);
        this.form.get('driversLicenceProvinceSeqNo').addValidators([Validators.required]);
      }

      if (ctryId == this.canadaFound[0]?.ctryId) {
        this.form.get('postalCode').addValidators([Validators.minLength(6)]);
        this.form.get("addressProvince").setValue(this.bcFound[0].provNm);
        this.form.get("addressProvinceSeqNo").setValue(this.bcFound[0].provSeqNo)
        this.form.get("addressProvinceProvId").setValue(this.bcFound[0].provId);
        this.form.get("driversLicenceProvince").setValue(this.bcFound[0].provNm);
        this.form.get("driversLicenceProvinceSeqNo").setValue(this.bcFound[0].provSeqNo)
        this.form.get("driversLicenceProvinceProvId").setValue(this.bcFound[0].provId);
      }

      this.form.get('postalCode').updateValueAndValidity();
      this.form.get('addressProvince').updateValueAndValidity();
      this.form.get("addressProvinceCountryId").updateValueAndValidity();
      this.form.get("addressProvinceSeqNo").updateValueAndValidity();
      this.form.get("addressProvinceProvId").updateValueAndValidity();
      this.form.get('homePhoneNumber').updateValueAndValidity();
      this.form.get('driversLicenceProvince').updateValueAndValidity();
      this.form.get("driversLicenceProvinceSeqNo").updateValueAndValidity();
      this.form.get("driversLicenceProvince").updateValueAndValidity();
      this.form.get("driversLicenceCountryId").updateValueAndValidity();
      this.onDLProvinceChange(this.form.get('driversLicenceProvince').value);
    }, 5);
  }

  public onDLProvinceChange(provId: number) {
    setTimeout(() => {
      let provFound = this.config.provincesAndStates.filter(x => x.provId === provId);
      if (provFound.length === 0) return;
      this.form.get("driversLicenceProvince").setValue(provFound[0]?.provNm);
      this.form.get("driversLicenceCountryId").setValue(provFound[0]?.ctryId);
      this.form.get("driversLicenceProvinceSeqNo").setValue(provFound[0]?.provSeqNo);
      if (provFound[0].provAbbreviationCd == 'BC') {
        this.form.get('driversLicenceNumber').setValidators([Validators.maxLength(9)]);
        this.form.get('driversLicenceNumber').addValidators([Validators.minLength(7)]);
      } else {
        this.form.get('driversLicenceNumber').setValidators([Validators.maxLength(20)]);
      }
      if (provFound[0].ctryId == this.usaFound[0].ctryId || provFound[0].ctryId == this.canadaFound[0].ctryId) {
        this.form.get('driversLicenceNumber').addValidators([Validators.required]);
      }
      this.form.get('driversLicenceNumber').updateValueAndValidity();
    }, 5)
  }

  public onAddressProvinceChange(provId: number) {
    setTimeout(() => {
      let provFound = this.config.provincesAndStates.filter(x => x.provId === provId);
      this.form.get("addressProvince").setValue(provFound[0].provNm);
      this.form.get("addressProvinceCountryId").setValue(provFound[0].ctryId);
      this.form.get("addressProvinceSeqNo").setValue(provFound[0].provSeqNo);
    }, 0)
  }

  public onSubmit(): void {
    this.putDispute({ ...this.lastUpdatedDispute, ...this.form.value });
  }

  public approve(): void {
    const data: DialogOptions = {
      titleKey: "Approve ticket resolution request?",
      messageKey:
        "Once you approve this request, the information will be sent to ICBC. Are you sure you are ready to approve and submit this request to ARC?",
      actionTextKey: "Approve and send request",
      actionType: "green",
      cancelTextKey: "Go back",
      icon: "error_outline",
    };
    this.lastUpdatedDispute.status = 'PROCESSING';
    this.dialog.open(ConfirmDialogComponent, { data }).afterClosed()
      .subscribe((action: any) => {
        if (action) {
          // submit dispute and return to TRM home
          this.busy = this.disputeService.submitDispute(this.lastUpdatedDispute.disputeId).subscribe({
            next: response => {
              this.lastUpdatedDispute.status = 'PROCESSING';
              this.onBack();
            },
            error: err => { },
            complete: () => { }
          });
        }
      });
  }

  public resendEmailVerification() {
    this.disputeService.resendEmailVerification(this.lastUpdatedDispute.disputeId)
      .subscribe(email => {
        const data: DialogOptions = {
          titleKey: "Email Verification Resent",
          icon: "email",
          actionType: "green",
          messageKey:
            "The email verification has been resent to the contact email address provided.\n\n" + this.lastUpdatedDispute.emailAddress,
          actionTextKey: "Ok",
          cancelHide: true
        };
        this.dialog.open(ConfirmDialogComponent, { data }).afterClosed()
          .subscribe((action: any) => {
          });
      })
  }

  public reject(): void {
    const data: DialogOptions = {
      titleKey: "Reject ticket resolution request?",
      messageKey:
        "Please enter the reason this request is being rejected. This information will be sent to the user in email notification.",
      actionTextKey: "Send rejection notification",
      actionType: "warn",
      cancelTextKey: "Go back",
      icon: "error_outline",
      message: this.form.get('rejectedReason').value
    };
    this.dialog.open(ConfirmReasonDialogComponent, { data }).afterClosed()
      .subscribe((action?: any) => {
        if (action?.output?.response) {
          this.form.get('rejectedReason').setValue(action.output.reason); // update on form for appearances
          this.lastUpdatedDispute.rejectedReason = action.output.reason; // update to send back on put

          // udate the reason entered, reject dispute and return to TRM home
          this.busy = this.disputeService.rejectDispute(this.lastUpdatedDispute.disputeId, this.lastUpdatedDispute.rejectedReason).subscribe({
            next: response => {
              this.lastUpdatedDispute.status = 'REJECTED';
              this.lastUpdatedDispute.rejectedReason = action.output.reason;
              this.onBack();
            },
            error: err => { },
            complete: () => { }
          });
        }
      });
  }

  public cancel(): void {
    const data: DialogOptions = {
      titleKey: "Cancel ticket resolution request?",
      messageKey:
        "Please enter the reason this request is being cancelled. This information will be sent to the user in email notification.",
      actionTextKey: "Send cancellation notification",
      actionType: "warn",
      cancelTextKey: "Go back",
      icon: "error_outline",
      message: this.form.get('rejectedReason').value
    };
    this.dialog.open(ConfirmReasonDialogComponent, { data }).afterClosed()
      .subscribe((action?: any) => {
        if (action?.output?.response) {
          this.form.get('rejectedReason').setValue(action.output.reason); // update on form for appearances
          this.lastUpdatedDispute.rejectedReason = action.output.reason; // update to send back on put

          // udate the reason entered, cancel dispute and return to TRM home since this will be filtered out
          this.busy = this.disputeService.putDispute(this.lastUpdatedDispute.disputeId, this.lastUpdatedDispute).subscribe({
            next: response => {
              this.disputeService.cancelDispute(this.lastUpdatedDispute.disputeId).subscribe({
                next: response => {
                  this.lastUpdatedDispute.status = 'CANCELLED';
                  this.lastUpdatedDispute.rejectedReason = action.output.reason;
                  this.onBack();
                },
                error: err => { },
                complete: () => { }
              });
            },
            error: err => { },
            complete: () => { }
          });
        }
      });
  }

  onKeyPressNumbers(event: any, BCOnly: boolean) {
    var charCode = (event.which) ? event.which : event.keyCode;
    // Only Numbers 0-9
    if ((charCode < 48 || charCode > 57) && BCOnly) {
      event.preventDefault();
      return false;
    } else {
      return true;
    }
  }

  // put dispute by id
  putDispute(dispute: Dispute): void {
    this.logger.log('ContactInfoComponent::putDispute', dispute);

    this.busy = this.disputeService.putDispute(dispute.disputeId, dispute).subscribe((response: Dispute) => {
      this.logger.info(
        'ContactInfoComponent::putDispute response',
        response
      );

      // this structure contains last version of what was send to db
      this.lastUpdatedDispute = response;
      this.form.markAsUntouched();
    });
  }

  // get dispute by id
  getDispute(): void {
    this.logger.log('ContactInfoComponent::getDispute');

    this.busy = this.disputeService.getDispute(this.disputeInfo.disputeId).subscribe((response: Dispute) => {
      this.retrieving = false;
      this.logger.info(
        'ContactInfoComponent::getDispute response',
        response
      );

      this.initialDisputeValues = response;
      this.lastUpdatedDispute = this.initialDisputeValues;

      // set violation date and time
      let tempViolationDate = this.lastUpdatedDispute?.issuedTs?.split("T");
      if (tempViolationDate) {
        this.violationDate = tempViolationDate[0];
        this.violationTime = tempViolationDate[1].split(":")[0] + ":" + tempViolationDate[1].split(":")[1];
      }


      this.form.patchValue(this.initialDisputeValues);

      this.onCountryChange(this.form.get('addressCountryId').value);
    });
  }

  public onBack() {
    this.backInbox.emit();
  }

  public handleCollapse(name: string) {
    this.collapseObj[name] = !this.collapseObj[name]
  }
}
