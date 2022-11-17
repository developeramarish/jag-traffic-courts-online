/**
 * VTC Staff API
 * Violation Ticket Centre Staff API
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { DisputeRepresentedByLawyer } from './disputeRepresentedByLawyer.model';
import { DisputeSystemDetectedOcrIssues } from './disputeSystemDetectedOcrIssues.model';
import { DisputeInterpreterRequired } from './disputeInterpreterRequired.model';
import { DisputeStatus } from './disputeStatus.model';
import { DisputeDisputantDetectedOcrIssues } from './disputeDisputantDetectedOcrIssues.model';
import { ViolationTicket } from './violationTicket.model';
import { DisputeCount } from './disputeCount.model';


export interface Dispute { 
    createdBy?: string | null;
    createdTs?: string;
    modifiedBy?: string | null;
    modifiedTs?: string | null;
    disputeId?: number;
    noticeOfDisputeGuid?: string | null;
    ticketNumber?: string | null;
    issuedTs?: string | null;
    submittedTs?: string | null;
    disputantSurname?: string | null;
    disputantGivenName1?: string | null;
    disputantGivenName2?: string | null;
    disputantGivenName3?: string | null;
    disputantBirthdate?: string | null;
    driversLicenceNumber?: string | null;
    disputantOrganization?: string | null;
    disputantClientId?: string | null;
    driversLicenceProvince?: string | null;
    status?: DisputeStatus;
    addressLine1?: string | null;
    addressLine2?: string | null;
    addressLine3?: string | null;
    addressCity?: string | null;
    addressProvince?: string | null;
    postalCode?: string | null;
    homePhoneNumber?: string | null;
    workPhoneNumber?: string | null;
    emailAddress?: string | null;
    emailAddressVerified?: boolean;
    filingDate?: string | null;
    representedByLawyer?: DisputeRepresentedByLawyer;
    lawFirmName?: string | null;
    lawyerSurname?: string | null;
    lawyerGivenName1?: string | null;
    lawyerGivenName2?: string | null;
    lawyerGivenName3?: string | null;
    lawyerAddress?: string | null;
    lawyerPhoneNumber?: string | null;
    lawyerEmail?: string | null;
    officerPin?: string | null;
    detachmentLocation?: string | null;
    interpreterLanguage?: string | null;
    interpreterRequired?: DisputeInterpreterRequired;
    witnessNo?: number | null;
    fineReductionReason?: string | null;
    timeToPayReason?: string | null;
    disputantComment?: string | null;
    rejectedReason?: string | null;
    userAssignedTo?: string | null;
    userAssignedTs?: string | null;
    disputantDetectedOcrIssues?: DisputeDisputantDetectedOcrIssues;
    disputantOcrIssues?: string | null;
    systemDetectedOcrIssues?: DisputeSystemDetectedOcrIssues;
    ocrViolationTicket?: string | null;
    violationTicket?: ViolationTicket;
    disputeCounts?: Array<DisputeCount> | null;
    additionalProperties?: { [key: string]: any; } | null;
}

