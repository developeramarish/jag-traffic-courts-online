package ca.bc.gov.open.jag.tco.oracledataapi.mapper;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.Arrays;
import java.util.Date;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;

import ca.bc.gov.open.jag.tco.oracledataapi.BaseTestSuite;
import ca.bc.gov.open.jag.tco.oracledataapi.model.ContactType;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDispute;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeCourtAppearanceAPP;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeCourtAppearanceCrown;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeCourtAppearanceDATT;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeCourtAppearanceRoP;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeHearingType;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeRemark;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputeStatus;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputedCount;
import ca.bc.gov.open.jag.tco.oracledataapi.model.JJDisputedCountFinding;
import ca.bc.gov.open.jag.tco.oracledataapi.model.Plea;
import ca.bc.gov.open.jag.tco.oracledataapi.model.YesNo;
import ca.bc.gov.open.jag.tco.oracledataapi.util.RandomUtil;

public class JJDisputeMapperTest extends BaseTestSuite {

	@Autowired
	private JJDisputeMapper jjDisputeMapper;

	@Autowired
	private TicketImageDataMapper ticketImageDataMapper;

	@Test
	public void testJJDispute() throws Exception {
		String addressLine1 = "123 Main St";
		String addressLine2 = "234 Main St";
		String addressLine3 = "345 Main St";
		String addressCity = "Someville";
		String addressProvince = "BC";
		String addressCountry = "Canada";
		String addressPostalCode = "A1A1A1";
		JJDisputeHearingType hearingType = JJDisputeHearingType.COURT_APPEARANCE;
		String contactLawFirm = "contactLawFirm";
		String contactGiven1Nm = "contactGiven1Nm";
		String contactGiven2Nm = "contactGiven2Nm";
		String contactGiven3Nm = "contactGiven3Nm";
		String contactSurnameNm = "contactSurnameNm";
		ContactType contactType = ContactType.INDIVIDUAL;
		String courtAgenId = "111";
		String detachmentLocation = "Detachment Location";
		Date disputantBirthDt =  RandomUtil.randomDate();
		String disputantDrvLicNumber = "1234567";
		String disputantGiven1Nm = "Given1";
		String disputantGiven2Nm = "Given2";
		String disputantGiven3Nm = "Given3";
		String disputantSurname = "Surname";
		String disputeId = "42";
		JJDisputeStatus disputeStatus = JJDisputeStatus.NEW;
		String drvLicIssuedCtryId = "2";
		String drvLicIssuedProvSeqNo = "1";
		YesNo electronicTicketYn = YesNo.Y;
		String emailAddress = "someone@somewhere.com";
		String fineReductionReasonTxt = "just because";
		String jjAssignedTo = "jjAssignedTo";
		Date jjDecisionDt = RandomUtil.randomDate();
		String justinRccId = "12345";
		Date icbcReceivedDt = RandomUtil.randomDate();
		String interpreterLanguageCd = "1";
		Date issuedTs = RandomUtil.randomDate();
		String lawFirmNm = "LawFirm";
		String lawyerGiven1Nm = "LawyerGiven1";
		String lawyerGiven2Nm = "LawyerGiven2";
		String lawyerGiven3Nm = "LawyerGiven3";
		String lawyerSurnameNm = "LawyerSurname";
		String noticeOfDisputeGuid = "noticeOfDisputeGuid";
		YesNo noticeOfHearingYn = YesNo.Y;
		String occamDisputantGiven1Nm = "name1";
		String occamDisputantGiven2Nm = "name2";
		String occamDisputantGiven3Nm = "name3";
		String occamDisputantSurnameNm = "lname";
		String occamDisputeId = "444";
		String occamViolationTicketUpldId = "5555";
		String offenceLocationTxt = "5555";
		Date submittedDt =  RandomUtil.randomDate();
		String ticketNumber = "EA90100004";
		String timeToPayReason = "just because";
		Date violationDt = RandomUtil.randomDate();
		String vtcAssignedTo = "vtcAssignedTo";
		Date vtcAssignedDtm = RandomUtil.randomDate();
		String witnessNo = "77";
		Date createdTs =  RandomUtil.randomDate();
		String createdBy = "1";
		Date modifiedTs =  RandomUtil.randomDate();
		String modifiedBy = "2";
		YesNo requestCourtAppearanceYn = YesNo.Y;

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute source = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute();
		source.setAddressLine1Txt(addressLine1);
		source.setAddressLine2Txt(addressLine2);
		source.setAddressLine3Txt(addressLine3);
		source.setAddressCityTxt(addressCity);
		source.setAddressProvinceTxt(addressProvince);
		source.setAddressCountryTxt(addressCountry);
		source.setAddressPostalCodeTxt(addressPostalCode);
		source.setCourtHearingTypeCd(hearingType.getShortName());
		source.setContactLawFirmNm(contactLawFirm);
		source.setContactGiven1Nm(contactGiven1Nm);
		source.setContactGiven2Nm(contactGiven2Nm);
		source.setContactGiven3Nm(contactGiven3Nm);
		source.setContactSurnameNm(contactSurnameNm);
		source.setContactTypeCd(contactType.getShortName());
		source.setCourtAgenId(courtAgenId);
		source.setDetachmentLocationTxt(detachmentLocation);
		source.setDisputantBirthDt(disputantBirthDt);
		source.setDisputantDrvLicNumberTxt(disputantDrvLicNumber);
		source.setDisputantGiven1Nm(disputantGiven1Nm);
		source.setDisputantGiven2Nm(disputantGiven2Nm);
		source.setDisputantGiven3Nm(disputantGiven3Nm);
		source.setDisputantSurnameTxt(disputantSurname);
		source.setDisputeId(disputeId);
		source.setDisputeStatusTypeCd(disputeStatus.getShortName());
		source.setDrvLicIssuedCtryId(drvLicIssuedCtryId);
		source.setDrvLicIssuedProvSeqNo(drvLicIssuedProvSeqNo);
		source.setElectronicTicketYn(electronicTicketYn.toString());
		source.setEmailAddressTxt(emailAddress);
		source.setFineReductionReasonTxt(fineReductionReasonTxt);
		source.setJjAssignedTo(jjAssignedTo);
		source.setJjDecisionDt(jjDecisionDt);
		source.setJustinRccId(justinRccId);
		source.setIcbcReceivedDt(icbcReceivedDt);
		source.setInterpreterLanguageCd(interpreterLanguageCd);
		source.setIssuedTs(issuedTs);
		source.setLawFirmNm(lawFirmNm);
		source.setLawyerGiven1Nm(lawyerGiven1Nm);
		source.setLawyerGiven2Nm(lawyerGiven2Nm);
		source.setLawyerGiven3Nm(lawyerGiven3Nm);
		source.setLawyerSurnameNm(lawyerSurnameNm);
		source.setNoticeOfDisputeGuid(noticeOfDisputeGuid);
		source.setNoticeOfHearingYn(noticeOfHearingYn.toString());
		source.setOccamDisputantGiven1Nm(occamDisputantGiven1Nm);
		source.setOccamDisputantGiven2Nm(occamDisputantGiven2Nm);
		source.setOccamDisputantGiven3Nm(occamDisputantGiven3Nm);
		source.setOccamDisputantSurnameNm(occamDisputantSurnameNm);
		source.setOccamDisputeId(occamDisputeId);
		source.setOccamViolationTicketUpldId(occamViolationTicketUpldId);
		source.setOffenceLocationTxt(offenceLocationTxt);
		source.setRequestCourtAppearanceYn(requestCourtAppearanceYn.toString());
		source.setSubmittedDt(submittedDt);
		source.setTicketNumberTxt(ticketNumber);
		source.setTimeToPayReasonTxt(timeToPayReason);
		source.setViolationDt(violationDt);
		source.setVtcAssignedTo(vtcAssignedTo);
		source.setVtcAssignedDtm(vtcAssignedDtm);
		source.setWitnessNo(witnessNo);
		source.setEntDtm(createdTs);
		source.setEntUserId(createdBy);
		source.setUpdDtm(modifiedTs);
		source.setUpdUserId(modifiedBy);

		JJDispute target = jjDisputeMapper.convert(source);
		assertEquals(addressLine1, target.getAddressLine1());
		assertEquals(addressLine2, target.getAddressLine2());
		assertEquals(addressLine3, target.getAddressLine3());
		assertEquals(addressCity, target.getAddressCity());
		assertEquals(addressProvince, target.getAddressProvince());
		assertEquals(addressCountry, target.getAddressCountry());
		assertEquals(addressPostalCode, target.getAddressPostalCode());
		assertEquals(hearingType, target.getHearingType());
		assertEquals(contactLawFirm, target.getContactLawFirmName());
		assertEquals(contactGiven1Nm, target.getContactGivenName1());
		assertEquals(contactGiven2Nm, target.getContactGivenName2());
		assertEquals(contactGiven3Nm, target.getContactGivenName3());
		assertEquals(contactSurnameNm, target.getContactSurname());
		assertEquals(contactType, target.getContactType());
		assertEquals(courtAgenId, target.getCourtAgenId());
		assertEquals(detachmentLocation, target.getPoliceDetachment());
		assertEquals(disputantBirthDt, target.getDisputantBirthdate());
		assertEquals(disputantDrvLicNumber, target.getDriversLicenceNumber());
		assertEquals(disputeStatus, target.getStatus());
		assertEquals(drvLicIssuedCtryId, target.getDrvLicIssuedCtryId());
		assertEquals(drvLicIssuedProvSeqNo, target.getDrvLicIssuedProvSeqNo());
		assertEquals(electronicTicketYn, target.getElectronicTicketYn());
		assertEquals(emailAddress, target.getEmailAddress());
		assertEquals(fineReductionReasonTxt, target.getFineReductionReason());
		assertEquals(jjAssignedTo, target.getJjAssignedTo());
		assertEquals(jjDecisionDt, target.getJjDecisionDate());
		assertEquals(justinRccId, target.getJustinRccId());
		assertEquals(icbcReceivedDt, target.getIcbcReceivedDate());
		assertEquals(interpreterLanguageCd, target.getInterpreterLanguageCd());
		assertEquals(issuedTs, target.getIssuedTs());
		assertEquals(lawFirmNm, target.getLawFirmName());
		assertEquals(lawyerGiven1Nm, target.getLawyerGivenName1());
		assertEquals(lawyerGiven2Nm, target.getLawyerGivenName2());
		assertEquals(lawyerGiven3Nm, target.getLawyerGivenName3());
		assertEquals(lawyerSurnameNm, target.getLawyerSurname());
		assertEquals(noticeOfDisputeGuid, target.getNoticeOfDisputeGuid());
		assertEquals(noticeOfHearingYn, target.getNoticeOfHearingYn());
		assertEquals(occamDisputantGiven1Nm, target.getOccamDisputantGiven1Nm());
		assertEquals(occamDisputantGiven2Nm, target.getOccamDisputantGiven2Nm());
		assertEquals(occamDisputantGiven3Nm, target.getOccamDisputantGiven3Nm());
		assertEquals(occamDisputantSurnameNm, target.getOccamDisputantSurnameNm());
		assertEquals(Long.valueOf(occamDisputeId), target.getOccamDisputeId());
		assertEquals(occamViolationTicketUpldId, target.getOccamViolationTicketUpldId());
		assertEquals(offenceLocationTxt, target.getOffenceLocation());
		assertEquals(requestCourtAppearanceYn, target.getAppearInCourt());
		assertEquals(submittedDt, target.getSubmittedTs());
		assertEquals(ticketNumber, target.getTicketNumber());
		assertEquals(timeToPayReason, target.getTimeToPayReason());
		assertEquals(violationDt, target.getViolationDate());
		assertEquals(vtcAssignedTo, target.getVtcAssignedTo());
		assertEquals(vtcAssignedDtm, target.getVtcAssignedTs());
		assertEquals(Integer.valueOf(witnessNo), target.getWitnessNo());
	}

	@Test
	public void testJJDisputeCount() throws Exception {
		String disputeCountId = "42";
		String disputeId = "142";
		String countNo = "5";
		String statuteId = "77";
		Plea pleaCd = Plea.G;
		String ticketedAmt = "345.67";
		Date fineDueDt =  RandomUtil.randomDate();
		Date violationDt =  RandomUtil.randomDate();
		String adjustedAmt = "10.53";
		YesNo includesSurchargeYn = YesNo.Y;
		Date revisedDueDt =  RandomUtil.randomDate();
		String totalFineAmt = "123.45";
		String comments = "comments and more comments";
		YesNo requestTimeToPayYn = YesNo.Y;
		YesNo requestReductionYn = YesNo.Y;
		YesNo requestCourtAppearanceYn = YesNo.Y;
		Date countCreatedTs =  RandomUtil.randomDate();
		String countCreatedBy = "3";
		Date countModifedTs =  RandomUtil.randomDate();
		String countModifiedBy = "4";
		Long appearanceChargeCountId = Long.valueOf("55");
		Long courtAppearanceId = Long.valueOf("77");
		JJDisputedCountFinding findingResultCd = JJDisputedCountFinding.GUILTY;
		String lesserChargeDescTxt = "Description";
		String suspSntcProbationDurtnTxt = "suspSntcProbationDurtnTxt";
		String suspSntcProbationCondsTxt = "suspSntcProbationCondsTxt";
		String jailDurationTxt = "jailDurationTxt";
		YesNo jailIntermittentYn = YesNo.Y;
		String probationDurationTxt = "probationDurationTxt";
		String probationConditionsTxt = "probationConditionsTxt";
		String drivingProhibDurationTxt = "drivingProhibDurationTxt";
		String drivingProhibMvaSectionTxt = "drivingProhibMvaSectionTxt";
		YesNo dismissedYn = YesNo.Y;
		YesNo dismissedForWantProsecYn = YesNo.Y;
		YesNo withdrawnYn =YesNo.Y;
		YesNo abatementYn = YesNo.Y;
		String stayOfProceedingsByTxt = "stayOfProceedingsByTxt";
		String otherTxt = "otherTxt";
		Date accEntDtm =  RandomUtil.randomDate();
		String accEntUserId = "5";
		Date accUpdDtm =  RandomUtil.randomDate();
		String accUpdUserId = "6";

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute source = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute();

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDisputeCount disputeCount = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDisputeCount();
		disputeCount.setDisputeCountId(disputeCountId);
		disputeCount.setDisputeId(disputeId);
		disputeCount.setCountNo(countNo);
		disputeCount.setStatuteId(statuteId);
		disputeCount.setPleaCd(pleaCd.getShortName());
		disputeCount.setTicketedAmt(ticketedAmt);
		disputeCount.setFineDueDt(fineDueDt);
		disputeCount.setViolationDt(violationDt);
		disputeCount.setAdjustedAmt(adjustedAmt);
		disputeCount.setIncludesSurchargeYn(includesSurchargeYn.toString());
		disputeCount.setRevisedDueDt(revisedDueDt);
		disputeCount.setTotalFineAmt(totalFineAmt);
		disputeCount.setCommentsTxt(comments);
		disputeCount.setRequestTimeToPayYn(requestTimeToPayYn.toString());
		disputeCount.setRequestReductionYn(requestReductionYn.toString());
		disputeCount.setRequestCourtAppearanceYn(requestCourtAppearanceYn.toString());
		disputeCount.setEntDtm(countCreatedTs);
		disputeCount.setEntUserId(countCreatedBy);
		disputeCount.setUpdDtm(countModifedTs);
		disputeCount.setUpdUserId(countModifiedBy);
		disputeCount.setAppearanceChargeCountId(appearanceChargeCountId.toString());
		disputeCount.setCourtAppearanceId(courtAppearanceId.toString());
		disputeCount.setFindingResultCd(findingResultCd.getShortName());
		disputeCount.setLesserChargeDescTxt(lesserChargeDescTxt);
		disputeCount.setSuspSntcProbationDurtnTxt(suspSntcProbationDurtnTxt);
		disputeCount.setSuspSntcProbationCondsTxt(suspSntcProbationCondsTxt);
		disputeCount.setJailDurationTxt(jailDurationTxt);
		disputeCount.setJailIntermittentYn(jailIntermittentYn.name());
		disputeCount.setProbationDurationTxt(probationDurationTxt);
		disputeCount.setProbationConditionsTxt(probationConditionsTxt);
		disputeCount.setDrivingProhibDurationTxt(drivingProhibDurationTxt);
		disputeCount.setDrivingProhibMvaSectionTxt(drivingProhibMvaSectionTxt);
		disputeCount.setDismissedYn(dismissedYn.name());
		disputeCount.setDismissedForWantProsecYn(dismissedForWantProsecYn.name());
		disputeCount.setWithdrawnYn(withdrawnYn.name());
		disputeCount.setAbatementYn(abatementYn.name());
		disputeCount.setStayOfProceedingsByTxt(stayOfProceedingsByTxt);
		disputeCount.setOtherTxt(otherTxt);
		disputeCount.setAccEntDtm(accEntDtm);
		disputeCount.setAccEntUserId(accEntUserId);
		disputeCount.setAccUpdDtm(accUpdDtm);
		disputeCount.setAccUpdUserId(accUpdUserId);
		source.setDisputeCounts(Arrays.asList(disputeCount));

		JJDispute target = jjDisputeMapper.convert(source);
		JJDisputedCount jjDisputedCount = target.getJjDisputedCounts().get(0);

		assertEquals(Long.valueOf(disputeCountId), jjDisputedCount.getId());
		//		assertEquals(disputeId, jjDisputedCount.getJjDispute().getDisputeId());                         // TODO: field missing in model but exists in database
		assertEquals(Integer.valueOf(countNo), jjDisputedCount.getCount());
		//		assertEquals(statuteId, jjDisputedCount.getStatuteId());                                        // TODO: field missing in model but exists in database
		assertEquals(pleaCd, jjDisputedCount.getPlea());
		assertEquals(Float.valueOf(ticketedAmt.toString()), jjDisputedCount.getTicketedFineAmount());
		assertEquals(fineDueDt, jjDisputedCount.getDueDate());
		assertEquals(violationDt, jjDisputedCount.getViolationDate());
		assertEquals(Float.valueOf(adjustedAmt.toString()), jjDisputedCount.getLesserOrGreaterAmount());
		assertEquals(includesSurchargeYn, jjDisputedCount.getIncludesSurcharge());
		assertEquals(revisedDueDt, jjDisputedCount.getRevisedDueDate());
		assertEquals(Float.valueOf(totalFineAmt.toString()), jjDisputedCount.getTotalFineAmount());
		assertEquals(comments, jjDisputedCount.getComments());
		assertEquals(requestTimeToPayYn, jjDisputedCount.getRequestTimeToPay());
		assertEquals(requestReductionYn, jjDisputedCount.getRequestReduction());
		assertEquals(requestCourtAppearanceYn, jjDisputedCount.getAppearInCourt());
		assertEquals(countCreatedTs, jjDisputedCount.getCreatedTs());
		assertEquals(countCreatedBy, jjDisputedCount.getCreatedBy());
		assertEquals(countModifedTs, jjDisputedCount.getModifiedTs());
		assertEquals(countModifiedBy, jjDisputedCount.getModifiedBy());
		assertEquals(appearanceChargeCountId, jjDisputedCount.getJjDisputedCountRoP().getId());
		assertEquals(findingResultCd, jjDisputedCount.getJjDisputedCountRoP().getFinding());
		assertEquals(lesserChargeDescTxt, jjDisputedCount.getJjDisputedCountRoP().getLesserDescription());
		assertEquals(suspSntcProbationDurtnTxt, jjDisputedCount.getJjDisputedCountRoP().getSsProbationDuration());
		assertEquals(suspSntcProbationCondsTxt, jjDisputedCount.getJjDisputedCountRoP().getSsProbationConditions());
		assertEquals(jailDurationTxt, jjDisputedCount.getJjDisputedCountRoP().getJailDuration());
		assertEquals(jailIntermittentYn, jjDisputedCount.getJjDisputedCountRoP().getJailIntermittent());
		assertEquals(probationDurationTxt, jjDisputedCount.getJjDisputedCountRoP().getProbationDuration());
		assertEquals(probationConditionsTxt, jjDisputedCount.getJjDisputedCountRoP().getProbationConditions());
		assertEquals(drivingProhibDurationTxt, jjDisputedCount.getJjDisputedCountRoP().getDrivingProhibition());
		assertEquals(drivingProhibMvaSectionTxt, jjDisputedCount.getJjDisputedCountRoP().getDrivingProhibitionMVASection());
		assertEquals(dismissedYn, jjDisputedCount.getJjDisputedCountRoP().getDismissed());
		assertEquals(dismissedForWantProsecYn, jjDisputedCount.getJjDisputedCountRoP().getForWantOfProsecution());
		assertEquals(withdrawnYn, jjDisputedCount.getJjDisputedCountRoP().getWithdrawn());
		assertEquals(abatementYn, jjDisputedCount.getJjDisputedCountRoP().getAbatement());
		assertEquals(stayOfProceedingsByTxt, jjDisputedCount.getJjDisputedCountRoP().getStayOfProceedingsBy());
		assertEquals(otherTxt, jjDisputedCount.getJjDisputedCountRoP().getOther());
		assertEquals(accEntDtm, jjDisputedCount.getJjDisputedCountRoP().getCreatedTs());
		assertEquals(accEntUserId, jjDisputedCount.getJjDisputedCountRoP().getCreatedBy());
		assertEquals(accUpdDtm, jjDisputedCount.getJjDisputedCountRoP().getModifiedTs());
		assertEquals(accUpdUserId, jjDisputedCount.getJjDisputedCountRoP().getModifiedBy());
	}

	@Test
	public void testJJDisputeRemark() throws Exception {
		String disputeRemarkId = "142";
		String disputeRemarkTxt = "This is a test remark";
		String fullUserNameTxt = "John Smith";
		Date remarksMadeDtm = RandomUtil.randomDate();
		Date remarkCreatedTs =  RandomUtil.randomDate();
		String remarkCreatedBy = "5";
		Date remarkModifedTs =  RandomUtil.randomDate();
		String remarkModifiedBy = "6";

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute source = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute();

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDisputeRemark disputeRemark = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDisputeRemark();
		disputeRemark.setDisputeRemarkId(disputeRemarkId);
		disputeRemark.setDisputeRemarkTxt(disputeRemarkTxt);
		disputeRemark.setFullUserNameTxt(fullUserNameTxt);
		disputeRemark.setRemarksMadeDtm(remarksMadeDtm);
		disputeRemark.setEntDtm(remarkCreatedTs);
		disputeRemark.setEntUserId(remarkCreatedBy);
		disputeRemark.setUpdDtm(remarkModifedTs);
		disputeRemark.setUpdUserId(remarkModifiedBy);
		source.setDisputeRemarks(Arrays.asList(disputeRemark));

		JJDispute target = jjDisputeMapper.convert(source);
		JJDisputeRemark jjDisputeRemark = target.getRemarks().get(0);

		assertEquals(Long.valueOf(disputeRemarkId ), jjDisputeRemark.getId());
		assertEquals(disputeRemarkTxt, jjDisputeRemark.getNote());
		assertEquals(fullUserNameTxt, jjDisputeRemark.getUserFullName());
		assertEquals(remarksMadeDtm, jjDisputeRemark.getRemarksMadeTs());
		assertEquals(remarkCreatedTs, jjDisputeRemark.getCreatedTs());
		assertEquals(remarkCreatedBy, jjDisputeRemark.getCreatedBy());
		assertEquals(remarkModifedTs, jjDisputeRemark.getModifiedTs());
		assertEquals(remarkModifiedBy, jjDisputeRemark.getModifiedBy());
	}

	@Test
	public void testTicketImageData() throws Exception {

		String reportType = "NOTICE_OF_DISPUTE";
		String index = RandomUtil.randomAlphabetic(5);
		String partId = RandomUtil.randomAlphanumeric(10);
		String participantName = RandomUtil.randomGivenName() + " " + RandomUtil.randomSurname();
		String reportFormat = RandomUtil.randomAlphabetic(5);
		String data = RandomUtil.randomAlphanumeric(1000);

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.TicketImageDataJustinDocument justinDocument = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.TicketImageDataJustinDocument();
		justinDocument.setReportType(reportType);
		justinDocument.setIndex(index);
		justinDocument.setPartId(partId);
		justinDocument.setParticipantName(participantName);
		justinDocument.setReportFormat(reportFormat);
		justinDocument.setData(data);

		ca.bc.gov.open.jag.tco.oracledataapi.model.TicketImageDataJustinDocument doc = ticketImageDataMapper.convert(justinDocument);

		assertEquals(reportType, doc.getReportType().getShortName());
		assertEquals(index, doc.getIndex());
		assertEquals(partId, doc.getPartId());
		assertEquals(participantName, doc.getParticipantName());
		assertEquals(reportFormat, doc.getReportFormat());
		assertEquals(data, doc.getFileData());
	}

	@Test
	public void testJJDisputeCourtAppearanceRoP() throws Exception {
		String courtAppearanceId = "21";
		String courtroomNumberTxt = "001";
		Date appearanceDtm = RandomUtil.randomDate();
		String appearanceReasonTxt = "HR";
		JJDisputeCourtAppearanceAPP disputantPresenceCd = JJDisputeCourtAppearanceAPP.P;
		Date disputantNotPresentDtm = RandomUtil.randomDate();
		String recordingClerkNameTxt = "Clerk";
		String defenceCounselNameTxt = "Counsel";
		JJDisputeCourtAppearanceCrown crownPresenceCd = JJDisputeCourtAppearanceCrown.N;
		YesNo seizedYn = YesNo.Y;
		String judgeOrJjNameTxt = "Judge";
		JJDisputeCourtAppearanceDATT defenceCounselPresenceCd = JJDisputeCourtAppearanceDATT.C;
		String commentsTxt = "This is a comment";
		Date courtAppearanceTs =  RandomUtil.randomDate();
		String courtAppearanceCreatedBy = "5";
		Date courtAppearanceModifedTs =  RandomUtil.randomDate();
		String courtAppearanceModifiedBy = "6";
		Integer durationHours = 1;
		Integer durationMinutes = 15;

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute source = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJDispute();

		ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJCourtAppearance courtAppearance = new ca.bc.gov.open.jag.tco.oracledataapi.ords.tco.api.model.JJCourtAppearance();

		courtAppearance.setAppearanceDtm(appearanceDtm);
		courtAppearance.setAppearanceReasonTxt(appearanceReasonTxt);
		courtAppearance.setCommentsTxt(commentsTxt);
		courtAppearance.setCourtAppearanceId(courtAppearanceId);
		courtAppearance.setCourtroomNumberTxt(courtroomNumberTxt);
		courtAppearance.setCrownPresenceCd(crownPresenceCd.toString());
		courtAppearance.setDefenceCounselNameTxt(defenceCounselNameTxt);
		courtAppearance.setDefenceCounselPresenceCd(defenceCounselPresenceCd.toString());
		courtAppearance.setDisputantNotPresentDtm(disputantNotPresentDtm);
		courtAppearance.setDisputantPresenceCd(disputantPresenceCd.toString());
		courtAppearance.setDurationHours(durationHours);
		courtAppearance.setDurationMinutes(durationMinutes);
		courtAppearance.setEntDtm(courtAppearanceTs);
		courtAppearance.setEntUserId(courtAppearanceCreatedBy);
		courtAppearance.setJudgeOrJjNameTxt(judgeOrJjNameTxt);
		courtAppearance.setRecordingClerkNameTxt(recordingClerkNameTxt);
		courtAppearance.setSeizedYn(seizedYn.name());
		courtAppearance.setUpdDtm(courtAppearanceModifedTs);
		courtAppearance.setUpdUserId(courtAppearanceModifiedBy);
		source.setCourtAppearances(Arrays.asList(courtAppearance));

		JJDispute target = jjDisputeMapper.convert(source);
		JJDisputeCourtAppearanceRoP courtAppearanceRoP = target.getJjDisputeCourtAppearanceRoPs().get(0);
		// Expected duration value is set to 75 minutes because initial duration values expected to be mapped above are set to 1 hour and 15 minutes
		short duration = (short)75;

		assertEquals(Long.valueOf(courtAppearanceId), courtAppearanceRoP.getId());
		assertEquals(courtroomNumberTxt, courtAppearanceRoP.getRoom());
		assertEquals(appearanceDtm, courtAppearanceRoP.getAppearanceTs());
		assertEquals(appearanceReasonTxt, courtAppearanceRoP.getReason());
		assertEquals(disputantPresenceCd, courtAppearanceRoP.getAppCd());
		assertEquals(disputantNotPresentDtm, courtAppearanceRoP.getNoAppTs());
		assertEquals(recordingClerkNameTxt, courtAppearanceRoP.getClerkRecord());
		assertEquals(defenceCounselNameTxt, courtAppearanceRoP.getDefenceCounsel());
		assertEquals(crownPresenceCd, courtAppearanceRoP.getCrown());
		assertEquals(seizedYn, courtAppearanceRoP.getJjSeized());
		assertEquals(judgeOrJjNameTxt, courtAppearanceRoP.getAdjudicator());
		assertEquals(defenceCounselPresenceCd, courtAppearanceRoP.getDattCd());
		assertEquals(commentsTxt, courtAppearanceRoP.getComments());
		assertEquals(duration, courtAppearanceRoP.getDuration());
		assertEquals(courtAppearanceTs, courtAppearanceRoP.getCreatedTs());
		assertEquals(courtAppearanceCreatedBy, courtAppearanceRoP.getCreatedBy());
		assertEquals(courtAppearanceModifedTs, courtAppearanceRoP.getModifiedTs());
		assertEquals(courtAppearanceModifiedBy, courtAppearanceRoP.getModifiedBy());
	}

}
