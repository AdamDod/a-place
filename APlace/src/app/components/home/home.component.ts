import { Component, OnInit} from '@angular/core';
import { AbstractControl, FormControl, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { Cell } from 'src/app/models/cell';
import { CellService } from 'src/service/cell.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  cells:Cell[] = [];
  rows:number[] = [...Array(100).keys()];
  colour:string = "#ffffff"


  constructor(private _cellService: CellService) {

  }

  ngOnInit(): void {
    this.loadCells();
  }

  loadCells():void{
    this._cellService.getCells().subscribe(unpackedCells => this.cells = unpackedCells,
      error => console.log("Error"+error.message),
      ()=>{
      });
  }

  modifyCell(c:Cell):void{
    c.colour = this.colour;
    this._cellService.changeCell(c).subscribe(unpackedCells => unpackedCells,
      error => console.log("Error"+error.message),
      ()=>{
        this.loadCells
      });
  }

  changeCell(c:Cell):void{
    this.modifyCell(c);
  }

  changeColour(colour:string):void{
    this.colour = colour;
  }
}
