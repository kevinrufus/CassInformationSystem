import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ResponseModel } from 'src/shared/models/ResponseModel';
import { ShipperService, ShipperShipmentDetails } from 'src/shared/services/shipper-service';

@Component({
  selector: 'app-shipper-shipment-details',
  templateUrl: './shipper-shipment-details.component.html',
  styleUrls: ['./shipper-shipment-details.component.css']
})
export class ShipperShipmentDetailsComponent implements OnInit {

  @Input() shipperId: number = 0;
  shipmentDetails: ShipperShipmentDetails[] = [];
  constructor(private shipperService: ShipperService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.shipperService.GetShipperShipmentDetails(this.shipperId).subscribe((response: ResponseModel<ShipperShipmentDetails[]>) => {
      this.shipmentDetails = response.data;
    });
  }

}
