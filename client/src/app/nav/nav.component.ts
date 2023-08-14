import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(
    public accService: AccountService,
    private router: Router,
    private toaster: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl(`/members`),
    });
    console.log(this.model);
  }

  logOut() {
    this.accService.logOut();
    this.router.navigateByUrl(`/`);
  }
}
