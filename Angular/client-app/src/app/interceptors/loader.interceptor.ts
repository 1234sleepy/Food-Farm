import { HttpInterceptorFn } from '@angular/common/http';
import { SpinnerService } from '../services/spinner.service';
import { inject, Inject } from '@angular/core';
import { delay, finalize } from 'rxjs';

export const loaderInterceptor: HttpInterceptorFn = (req, next) => {

  const spinner = inject(SpinnerService)


  spinner.show();


  return next(req).pipe(  
    finalize(() => spinner.hide()
    ));
};
