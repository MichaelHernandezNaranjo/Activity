export interface taskStatus {
    companyId: number;
    projectId: number;
    taskStatusId: number;
    taskStatusName: string;
    description: string | null;
    creationDate: Date;
}


export interface taskStatusRequest {
    companyId: number;
    projectId: number;
    taskStatusId: number;
    taskStatusName: string;
    CreationUserId: number;
    Active: boolean;
}