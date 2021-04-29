import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.scss']
})
export class NotasComponent implements OnInit {


public notas: any = [];
larguraImagem: number = 70;
margemImagem: number = 2;
exibirImagem: boolean = true;
private _filtroLista: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getNotas();
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getNotas() : void {

    this.http.get('https://localhost:5001/api/Caixa').subscribe(
      response => {
        this.notas = response;
      },
      error => console.log(error)
    );
  }
}
