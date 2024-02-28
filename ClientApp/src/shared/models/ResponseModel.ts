export interface ResponseModel<Type> {
    data: Type;
    message: string;
    returnStatus: number;
    isSuccess: boolean;
}