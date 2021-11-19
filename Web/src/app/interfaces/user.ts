export interface user {
    companyId: number;
    userId: number;
    userName: string;
    email: string;
    roleId: number;
    roleName: string;
    token: string;
}
export interface userRequest {
    companyId: number;
    userId: number;
    userName: string;
    roleId: number;
    CreationUserId: number;
    Active: boolean;
}

export interface userReponse {
    companyId: number;
    userId: number;
    userName: string;
    roleId: number;
    CreationUserId: number;
    Active: boolean;
}