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


export interface LegalRepresentation { 
    createdBy?: string | null;
    createdTs?: string;
    modifiedBy?: string | null;
    modifiedTs?: string;
    /**
     * ID
     */
    id?: string;
    lawFirmName?: string | null;
    lawyerFullName?: string | null;
    lawyerEmail?: string | null;
    lawyerAddress?: string | null;
    lawyerPhoneNumber?: string | null;
    additionalProperties?: { [key: string]: any; } | null;
}

