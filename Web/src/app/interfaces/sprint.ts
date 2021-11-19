export interface sprint {
    companyId: number;
    projectId: number;
    sprintId: number;
    sprintName: string;
    description: string | null;
    creationDate: Date;
}


export interface sprintRequest {
    companyId: number;
    projectId: number;
    sprintId: number;
    sprintName: string;
    description: string | null;
    CreationUserId: number;
    Active: boolean;
}