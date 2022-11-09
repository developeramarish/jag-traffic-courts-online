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
import { JJDisputeCourtAppearanceRoPApp } from './jJDisputeCourtAppearanceRoPApp.model';
import { JJDisputeCourtAppearanceRoPCrown } from './jJDisputeCourtAppearanceRoPCrown.model';


export interface JJDisputeCourtAppearanceRoP { 
    createdBy?: string | null;
    createdTs?: string;
    modifiedBy?: string | null;
    modifiedTs?: string | null;
    id?: number;
    appearanceTs?: string | null;
    room?: string | null;
    reason?: string | null;
    app?: JJDisputeCourtAppearanceRoPApp;
    noAppTs?: string | null;
    clerkRecord?: string | null;
    defenseCounsel?: string | null;
    crown?: JJDisputeCourtAppearanceRoPCrown;
    jjSeized?: string | null;
    adjudicator?: string | null;
    comments?: string | null;
    additionalProperties?: { [key: string]: any; } | null;
}
