import { Component, OnInit } from '@angular/core';
import { VistasService } from 'src/app/services/vistas.service';
import { VToken } from 'src/app/interfaces/views/v-token';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tokens',
  templateUrl: './tokens.component.html',
  styleUrls: []
})
export class TokensComponent implements OnInit {
  currentPage: number;
  paginationConfig: any;
  tokens: VToken[];

  constructor(private vistasService: VistasService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.currentPage = this.route.snapshot.params['pg'];
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.vistasService.getVistaTokens().subscribe(
      response => {
        if (response[0]) {
          this.tokens = response[0];
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.tokens.length
          };
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.router.navigate(['/tokens', this.currentPage]);
  }
}