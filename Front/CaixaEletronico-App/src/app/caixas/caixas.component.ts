import {HttpClient} from '@angular/common/http'
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-caixas',
  templateUrl: './caixas.component.html',
  styleUrls: ['./caixas.component.scss']
})
export class CaixasComponent implements OnInit {

  public caixas: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  public getCaixas() : void{
    this.http.get('https://localhost:5001/api/Nota').subscribe(
      response => {
        this.caixas = response;
      },
      error => console.log(error)
    );
  }
}
