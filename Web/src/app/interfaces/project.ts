
export interface project {
    companyId: number;
    projectId: number;
    projectName: string;
    description: string | null;
    creationDate: Date;
    listProjectUser: projectUser[] | null;
}

export interface projectUser {
    userId: number;
    userName: string;
}

export interface projectRequest {
    companyId: number;
    projectId: number;
    projectName: string;
    description: string | null;
    CreationUserId: number;
    Active: boolean;
}