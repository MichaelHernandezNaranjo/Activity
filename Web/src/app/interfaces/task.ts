export interface task {
    companyId: number;
    projectId: number;
    taskId: number;
    taskName: string;
    sprintId: number | null;
    description: string | null;
    taskStatusId: number;
    taskStatusName: string;
    creationDate: Date;
}


export interface taskRequest {
    companyId: number;
    projectId: number;
    taskId: number;
    taskName: string;
    sprintId: number | null;
    description: string | null;
    taskStatusId: number;
    taskStatusName: string;
    creationUserId: number;
    active: boolean;
}