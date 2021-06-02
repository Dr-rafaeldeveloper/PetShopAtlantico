import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-petalojs',
  templateUrl: './petalojs.component.html',
  styleUrls: ['./petalojs.component.scss']
})
export class PetalojsComponent implements OnInit {

  public petalojs: any = [];
  public petalojsFilters: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImg: boolean = true;
  private _listFilter: string = "";

  public get listFilter(): string {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;
    this.petalojsFilters = this.listFilter ? this.filterPetAloj(this.listFilter) : this.petalojs;
  }

  filterPetAloj(filterPor: string): any {
    filterPor = filterPor.toLocaleLowerCase();
    return this.petalojs.filter(
      (petaloj: { animalName: string; ownerName: string; }) => petaloj.animalName.toLocaleLowerCase().indexOf(filterPor) !== -1 ||
      petaloj.ownerName.toLocaleLowerCase().indexOf(filterPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPetAloj();
  }

  changeImg() {
    this.showImg = !this.showImg;
  }

  public getPetAloj(): void {
    this.http.get('https://localhost:5001/api/petalojs').subscribe(
      response => {
        this.petalojs = response;
        this.petalojsFilters = this.petalojs;
      },
      error => console.log(error)
    );
  }

}
