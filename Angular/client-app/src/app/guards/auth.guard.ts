import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';
import { Toast, ToastrService } from 'ngx-toastr';



export const authGuard: CanActivateFn = (route, state) => {

    const accountService = inject(AccountService);
    const toastr = inject(ToastrService);



    return accountService.getAuthState().pipe(
        map(user => {
            console.log(user);
            if (user) {
                return true;
            }else {
                toastr.error('You are not logged in');
                return false;
            }
        })
    );
};
