import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { JJDisputeStatus } from 'app/api';
import { DisputeService } from 'app/services/dispute.service';
import { AppState, DisputeStore } from 'app/store';

@Component({
  selector: 'app-update-dispute-landing',
  templateUrl: './update-dispute-landing.component.html',
  styleUrls: ['./update-dispute-landing.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class UpdateDisputeLandingComponent implements OnInit {
  private data: DisputeStore.StateData;
  public isEditable: boolean = true;

  constructor(
    private disputeService: DisputeService,
    private store: Store<AppState>,
  ) {
  }

  ngOnInit(): void {
    this.store.pipe(select(state => state.dispute.data?.dispute)).subscribe(dispute => {
      if (!dispute) {
        this.store.dispatch(DisputeStore.Actions.Search({}))
      } else {
        this.isEditable = !dispute.jjdispute_status || dispute.jjdispute_status === JJDisputeStatus.New;
      }
    })
    this.store.pipe(select(state => state.dispute.data)).subscribe(data => {
      this.data = data;
    })
  }

  checkStatus(): void {
    this.disputeService.showDisputeStatus(this.data);
  }
}
