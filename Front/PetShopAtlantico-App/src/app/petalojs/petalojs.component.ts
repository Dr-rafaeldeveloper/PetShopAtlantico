import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-petalojs',
  templateUrl: './petalojs.component.html',
  styleUrls: ['./petalojs.component.scss']
})
export class PetalojsComponent implements OnInit {

  public petalojs: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPetAloj();
  }

  public getPetAloj(): void {
    this.http.get('https://localhost:5001/api/petalojs').subscribe(
      response => this.petalojs = response,
      error => console.log(error)
    );
  }

}
