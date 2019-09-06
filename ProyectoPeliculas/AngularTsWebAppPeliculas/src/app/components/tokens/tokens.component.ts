import { Component, OnInit } from '@angular/core';
import { VistasService } from 'src/app/services/vistas.service';
import { Token } from 'src/app/interfaces/token';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tokens',
  templateUrl: './tokens.component.html',
  styleUrls: []
})
export class TokensComponent implements OnInit {
  currentPage: any;
  paginationConfig: any;
  tokens: Token[];

  constructor(private vistasService: VistasService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.currentPage = this.route.snapshot.params['pg'],
      this.paginationConfig = {
        itemsPerPage: 0,
        currentPage: 0,
        totalItems: 0
      };
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.tokens = [];
    this.vistasService.getTokensVista().subscribe(data => {
      this.tokens = data as Token[];
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.tokens.length
      };
    });
  }

  pageChanged(event) {
    this.currentPage = event;
    this.paginationConfig.currentPage = this.currentPage;
    this.router.navigate(['/tokens', this.currentPage]);
  }
}