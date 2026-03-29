import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { map } from 'rxjs';
import { Toast, ToastrService } from 'ngx-toastr';
import { AuthStoreService } from '../features/auth/services/stores/auth.store.service';



export const authGuard: CanActivateFn = (route, state) => {

    const accountService = inject(AuthStoreService);
    const toastr = inject(ToastrService);

    return accountService.getAuthState().pipe(
        map(user => {
            if (user) {
                return true;
            }else {
                toastr.error('You are not logged in');
                return false;
            }
        })
    );
};
