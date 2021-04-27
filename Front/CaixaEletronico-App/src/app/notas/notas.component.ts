import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.scss']
})
export class NotasComponent implements OnInit {

public notas: any ;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getNotas();
  }


  public getNotas() : void {

    this.http.get('https://localhost:5001/api/Nota').subscribe(
      response => {
        this.notas = response;
        // this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }
}
