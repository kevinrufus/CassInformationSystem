﻿namespace CassInformationSystemApi.DTOs
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int ReturnStatus { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        public ResponseModel()
        {
            IsSuccess = false;
            Message = String.Empty;
            ReturnStatus = 200;
            Data = default;
        }
        public ResponseModel(bool isSuccess, int returnStatus)
        {
            IsSuccess = isSuccess;
            ReturnStatus = returnStatus;
            Message = String.Empty;
            Data = default;
        }
        public ResponseModel(string errorMessage, int returnStatus)
        {
            IsSuccess = false;
            Message = errorMessage;
            ReturnStatus = returnStatus;
            Data = default;
        }
        public ResponseModel(Object? data, int returnStatus, bool isSuccess)
        {
            IsSuccess = isSuccess;
            Data = data;
            ReturnStatus = returnStatus;
            Message = String.Empty;
        }
        public ResponseModel(Object? data, int returnStatus, bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            ReturnStatus = returnStatus;
            Message = message;
        }

    }
}
