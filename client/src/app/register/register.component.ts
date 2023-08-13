import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  @Output() formCancel = new EventEmitter<boolean>();

  constructor(private accService: AccountService) {}

  model: any = {};

  register() {
    this.accService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: (err) => console.log(err),
    });
  }

  cancel() {
    this.formCancel.emit(false);
  }
}
