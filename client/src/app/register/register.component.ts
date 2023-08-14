import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  @Output() formCancel = new EventEmitter<boolean>();

  constructor(
    private accService: AccountService,
    private toastr: ToastrService
  ) {}

  model: any = {};

  register() {
    this.accService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: (err) => {
        this.toastr.error(err.error);
        console.log(err);
      },
    });
  }

  cancel() {
    this.formCancel.emit(false);
  }
}
