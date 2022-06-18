import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cell } from 'src/app/models/cell';

@Injectable({
  providedIn: 'root'
})
export class CellService {
  readonly baseUrl: string = "https://aplaceapi.azurewebsites.net/";

  constructor(private _http: HttpClient) { }

  getCells(): Observable<Cell[]>{
    return this._http.get<Cell[]>(this.baseUrl + "cells");
  }

  changeCell(cell : Cell): Observable<string>{
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(cell);
    return this._http.put<string>(this.baseUrl + 'cells', body, { 'headers': headers })
  }
}
