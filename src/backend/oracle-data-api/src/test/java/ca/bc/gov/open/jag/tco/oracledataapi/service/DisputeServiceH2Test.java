package ca.bc.gov.open.jag.tco.oracledataapi.service;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.junit.jupiter.api.Assertions.assertThrows;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.UUID;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.EnumSource;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.condition.ConditionalOnProperty;

import ca.bc.gov.open.jag.tco.oracledataapi.BaseTestSuite;
import ca.bc.gov.open.jag.tco.oracledataapi.error.NotAllowedException;
import ca.bc.gov.open.jag.tco.oracledataapi.model.DisputantUpdateRequest;
import ca.bc.gov.open.jag.tco.oracledataapi.model.DisputantUpdateStatus;
import ca.bc.gov.open.jag.tco.oracledataapi.model.DisputantUpdateType;
import ca.bc.gov.open.jag.tco.oracledataapi.model.Dispute;
import ca.bc.gov.open.jag.tco.oracledataapi.model.DisputeStatus;

@ConditionalOnProperty(name = "repository.dispute", havingValue = "h2", matchIfMissing = true)
class DisputeServiceH2Test extends BaseTestSuite {

	@Autowired
	private DisputeService disputeService;

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "NEW", "REJECTED", "VALIDATED" })
	void testSetStatusToPROCESSING_200(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		disputeService.setStatus(id, DisputeStatus.PROCESSING);
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "CANCELLED", "PROCESSING" })
	void testSetStatusToPROCESSING_405(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, DisputeStatus.PROCESSING);
		});
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "NEW" })
	void testSetStatusToVALIDATED_200(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		disputeService.setStatus(id, DisputeStatus.VALIDATED);
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "CANCELLED", "PROCESSING", "VALIDATED" })
	void testSetStatusToVALIDATED_405(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, DisputeStatus.VALIDATED);
		});
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "NEW", "VALIDATED" })
	void testSetStatusToREJECTED_200(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		disputeService.setStatus(id, DisputeStatus.REJECTED);
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "CANCELLED", "PROCESSING", "REJECTED" })
	void testSetStatusToREJECTED_405(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, DisputeStatus.REJECTED);
		});
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "NEW", "PROCESSING", "REJECTED", "VALIDATED" })
	void testSetStatusToCANCELLED_200(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		disputeService.setStatus(id, DisputeStatus.CANCELLED);
	}

	@ParameterizedTest
	@EnumSource(value = DisputeStatus.class, names = { "CANCELLED" })
	void testSetStatusToCANCELLED_405(DisputeStatus disputeStatus) {
		Long id = saveDispute(disputeStatus);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, DisputeStatus.CANCELLED);
		});
	}

	@Test
	void testSetStatusToNEW_405() {
		Long id = saveDispute(DisputeStatus.NEW);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, DisputeStatus.NEW);
		});
	}

	@Test
	void testSetStatusToNULL_405() {
		Long id = saveDispute(null);
		assertThrows(NotAllowedException.class, () -> {
			disputeService.setStatus(id, null);
		});
	}

	@Test
	public void testDisputantUpdateRequest() throws Exception {
		String noticeOfDisputeGuid = UUID.randomUUID().toString();

		Dispute dispute = new Dispute();
		dispute.setStatus(DisputeStatus.NEW);
		dispute.setNoticeOfDisputeGuid(noticeOfDisputeGuid);
		dispute = disputeRepository.save(dispute);

		String json = "{ \"address_line1\": \"123 Main Street\", \"address_line2\": \"\", \"address_line3\": \"\" }";
		DisputantUpdateRequest updateRequest = new DisputantUpdateRequest();
		updateRequest.setDisputeId(Long.valueOf(1L));
		updateRequest.setStatus(DisputantUpdateStatus.PENDING);
		updateRequest.setUpdateType(DisputantUpdateType.DISPUTANT_ADDRESS);
		updateRequest.setUpdateJson(json);
		DisputantUpdateRequest savedUpdateReq = disputeService.saveDisputantUpdateRequest(noticeOfDisputeGuid, updateRequest);
		Long disputantUpdateRequestId = savedUpdateReq.getDisputantUpdateRequestId();

		assertNotNull(disputantUpdateRequestId);

		List<DisputantUpdateRequest> updateRequests = disputeService.findDisputantUpdateRequestByDisputeId(dispute.getDisputeId());

		assertEquals(1, updateRequests.size());
		savedUpdateReq = updateRequests.get(0);

		assertEquals(dispute.getDisputeId(), savedUpdateReq.getDisputeId().longValue());
		assertEquals(DisputantUpdateStatus.PENDING, savedUpdateReq.getStatus());
		assertEquals(DisputantUpdateType.DISPUTANT_ADDRESS, savedUpdateReq.getUpdateType());
		assertEquals(json, savedUpdateReq.getUpdateJson());

		savedUpdateReq = disputeService.updateDisputantUpdateRequest(disputantUpdateRequestId, DisputantUpdateStatus.ACCEPTED);
		assertEquals(DisputantUpdateStatus.ACCEPTED, savedUpdateReq.getStatus());
	}

	@Test
	public void testDisputantUpdateRequest_404() throws Exception {
		assertThrows(NoSuchElementException.class, () -> {
			disputeService.saveDisputantUpdateRequest("some-guid", new DisputantUpdateRequest());
		});
	}

	private Long saveDispute(DisputeStatus disputeStatus) {
		Dispute dispute = new Dispute();
		dispute.setStatus(disputeStatus);

		return disputeRepository.save(dispute).getDisputeId();
	}

}
