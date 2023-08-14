import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const accService = inject(AccountService);
  const toastr = inject(ToastrService);
  const router = inject(Router);

  return accService.currentUser$.pipe(
    map((user) => {
      if (user) return true;

      router.navigateByUrl('/');
      toastr.error('not authorized access');
      return false;
    })
  );
};
