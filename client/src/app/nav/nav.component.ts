import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MembersService } from '../services/members.service';

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
    private memService: MembersService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accService.login(this.model).subscribe({
      next: () => {
        this.router.navigateByUrl(`/members`);
        this.memService.resetUserParams();
      },
    });
  }

  logOut() {
    this.accService.logOut();
    this.router.navigateByUrl(`/`);
  }
}
