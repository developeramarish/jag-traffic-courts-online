import { Component, Input, OnChanges, OnInit } from "@angular/core";
import { DisputeContactTypeCd, DisputeRepresentedByLawyer, DisputeRequestCourtAppearanceYn, ViolationTicketCount } from "app/api";
import { LookupsService } from "app/services/lookups.service";
import { NoticeOfDisputeService, NoticeOfDispute, CountsActions, DisputeCount } from "app/services/notice-of-dispute.service";
import { ConfigService } from "@config/config.service";

@Component({
  selector: "app-dispute-ticket-summary",
  templateUrl: "./dispute-ticket-summary.component.html",
  styleUrls: ["./dispute-ticket-summary.component.scss"],
})
export class DisputeTicketSummaryComponent implements OnInit, OnChanges {
  @Input() noticeOfDispute: NoticeOfDispute;
  @Input() ticketCounts: ViolationTicketCount[] = [];
  countsActions: CountsActions;
  RepresentedByLawyer = DisputeRepresentedByLawyer;
  ContactType = DisputeContactTypeCd;
  RequestCourtAppearance = DisputeRequestCourtAppearanceYn;

  constructor(
    private configService: ConfigService,
    private noticeOfDisputeService: NoticeOfDisputeService,
    private lookups: LookupsService
  ) {
  }

  ngOnInit(): void {
    if (this.noticeOfDispute) {
      this.countsActions = this.noticeOfDisputeService.getCountsActions(this.noticeOfDispute.dispute_counts);
    }
  }

  ngOnChanges(): void {
    if (this.noticeOfDispute) {
      this.countsActions = this.noticeOfDisputeService.getCountsActions(this.noticeOfDispute.dispute_counts);
    }
  }

  getLanguageDescription(lang): string {
    return this.lookups.getLanguageDescription(lang);
  }

  getCountryLongName(countryId: number): string {
    return this.configService.getCtryLongNm(countryId);
  }

  getCount(disputeCount: DisputeCount): ViolationTicketCount {
    return this.ticketCounts?.filter(i => i.count_no === disputeCount.count_no).shift();
  }
}
