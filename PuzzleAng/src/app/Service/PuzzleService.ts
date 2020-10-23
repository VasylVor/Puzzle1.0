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
    resp: PuzzleResp;

    GetPuzzle(puzzleReq: PuzzleReq){
        const req = {id: puzzleReq.Id, heightR: puzzleReq.HeightRect, weidth: puzzleReq.WidthRect, BImage: puzzleReq.BImage};
       // resp = this.http.post(this.url ,req);
        return this.http.post(this.url ,req);
    }
}