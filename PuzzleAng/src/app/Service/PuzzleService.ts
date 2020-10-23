import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {PuzzleReq} from './PuzzleReq';
import { PuzzleResp } from './PuzzleResp';

@Injectable({
    providedIn: 'root'
  })
export class PuzzleServ{
    constructor(private http: HttpClient){}
    url = 'http://localhost:52871/api/GetPuzzle';
    resp: any;

    GetPuzzle(puzzleReq: PuzzleReq){
        const req = {id: puzzleReq.Id, heightR: puzzleReq.HeightRect, weidth: puzzleReq.WidthRect, BImage: puzzleReq.BImage};
       // resp = this.http.post(this.url ,req);
       this.http.post(this.url ,req).subscribe((response) =>{ this.resp = response;})
        return this.resp; 
       // Images: data.Images,
         //   Id: data.Id,-
           // Name: data.Name,
           // Error: data.Error
    }
}