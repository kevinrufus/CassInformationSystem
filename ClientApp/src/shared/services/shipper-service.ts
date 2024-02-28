import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private apiUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
   }

  getShippersList(): Observable<any> {
    return this.http.get<ResponseModel<ShippersList[]>>((this.apiUrl + 'Shippers/get-shippers'));
  }
  GetShipperShipmentDetails(shipperId: number): Observable<any>{
    return this.http.get<ResponseModel<ShipperShipmentDetails[]>>((this.apiUrl + 'Shippers/get-shipper-shipment-details'), {params: {shipperId: shipperId}});
  }
}

export interface ShippersList {
    shipperId: number;
    shipperName: string;
}

export interface ShipperShipmentDetails{
    shipment_Id: number;
    shipper_Name: string;
    carrier_Name: string;
    shipment_Description: string;
    shipment_Weight: number;
    shipment_Rate_Description: string;
}
