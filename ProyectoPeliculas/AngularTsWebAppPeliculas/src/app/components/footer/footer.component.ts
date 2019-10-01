import { Component } from '@angular/core';
import { GlobalService, logged } from 'src/app/global.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styles: []
})

export class FooterComponent  {
  constructor(private globalService: GlobalService) { }
}