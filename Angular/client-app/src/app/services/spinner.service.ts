import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  constructor(private spinner: NgxSpinnerService) { }
  private requestCount = 0;

  show() {
    this.requestCount++;
    this.spinner.show();
  }

  hide() {
    this.requestCount--;
    if(this.requestCount <= 0) {
      this.spinner.hide();
      this.requestCount = 0;
    }
  }
}
