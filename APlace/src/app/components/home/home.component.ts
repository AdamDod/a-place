import { Component, OnInit } from '@angular/core';
import { Cell } from 'src/app/models/cell';
import { CellService } from '../../services/cell.service';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  cells: Cell[] = [];
  rows: number[] = [...Array(100).keys()];
  colour: string = '#ffffff';
  hubConnection: signalR.HubConnection;
  data: Cell;

  constructor(private _cellService: CellService, private http: HttpClient) {}

  ngOnInit(): void {
    this.loadCells();
    // this.signalRService.startConnection();
    // this.signalRService.addCellChangeListener();
    this.startConnection();
    this.addCellChangeListener();
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://aplaceapi.azurewebsites.net/hub',{skipNegotiation:true,transport: signalR.HttpTransportType.WebSockets})
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err) => console.log('Error while starting connection: ' + err));
  };

  public addCellChangeListener = () => {
    this.hubConnection.on('update', (data) => {
      this.data = data;
      console.log(data);
      this.loadCells();
    });
  };


  loadCells(): void {
    this._cellService.getCells().subscribe(
      (unpackedCells) => (this.cells = unpackedCells),
      (error) => console.log('Error' + error.message),
      () => {}
    );
  }

  modifyCell(c: Cell): void {
    c.colour = this.colour;
    this._cellService.changeCell(c).subscribe(
      (unpackedCells) => unpackedCells,
      (error) => console.log('Error' + error.message),
      () => {
        this.loadCells;
      }
    );
  }

  changeCell(c: Cell): void {
    this.modifyCell(c);
  }

  changeColour(colour: string): void {
    this.colour = colour;
  }
}
