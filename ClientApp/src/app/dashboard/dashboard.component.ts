import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ResponseModel } from 'src/shared/models/ResponseModel';
import {
  ShipperService,
  ShippersList,
} from 'src/shared/services/shipper-service';
import { ShipperShipmentDetailsComponent } from './shipper-shipment-details/shipper-shipment-details.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  shippersList: ShippersList[] = [];
  constructor(
    private shipperService: ShipperService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.shipperService
      .getShippersList()
      .subscribe((response: ResponseModel<ShippersList[]>) => {
        this.shippersList = response.data;
      });
  }

  clickedItem(id: number): void {
    const modal = this.modalService.open(ShipperShipmentDetailsComponent, { size: 'xl' });
    modal.componentInstance.shipperId = id;
  }
}
