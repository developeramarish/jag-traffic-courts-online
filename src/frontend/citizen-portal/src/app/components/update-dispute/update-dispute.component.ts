import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { DisputeFormMode } from '@shared/enums/dispute-form-mode';
import { NoticeOfDisputeFormGroup } from '@shared/models/dispute-form.model';
import { DisputeService } from 'app/services/dispute.service';
import { NoticeOfDisputeService, NoticeOfDispute } from 'app/services/notice-of-dispute.service';
import { ViolationTicketService } from 'app/services/violation-ticket.service';
import { DisputeStore } from 'app/store';
import { filter, take } from 'rxjs';

@Component({
  selector: 'app-update-dispute',
  templateUrl: './update-dispute.component.html',
  styleUrls: ['./update-dispute.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class UpdateDisputeComponent implements OnInit {
  mode: DisputeFormMode = DisputeFormMode.UPDATE;
  noticeOfDispute: NoticeOfDispute;
  ticketType: string;

   constructor(
    private violationTicketService: ViolationTicketService,
    private disputeService: DisputeService,
    private store: Store,
  ) {
  }

  ngOnInit(): void {
    this.disputeService.checkStoredDispute().pipe(filter(i => !!i), take(1)).subscribe(found => {
      if (found) {
        this.store.pipe(select(DisputeStore.Selectors.NoticeOfDispute), filter(i => !!i)).subscribe(noticeOfDispute => {
          this.noticeOfDispute = noticeOfDispute;
          this.ticketType = this.violationTicketService.getTicketType(this.noticeOfDispute);
        })
        this.store.dispatch(DisputeStore.Actions.Get());
      }
    })
  }

  /**
   * @description
   * Submit the dispute
   */
  public submitDispute(noticeOfDispute): void {
    this.store.dispatch(DisputeStore.Actions.Update({ payload: noticeOfDispute }));
  }
}