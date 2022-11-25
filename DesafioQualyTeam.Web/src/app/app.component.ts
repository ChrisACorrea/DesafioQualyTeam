/* Angular Imports */
import { Component, OnInit } from '@angular/core';

/* PrimeNg Imports */
import { MenuItem, PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'DesafioQualyTeam.Web';
  items!: MenuItem[];

  constructor(private primengConfig: PrimeNGConfig) { }

  ngOnInit() {
    this.primengConfig.ripple = true;

    this.items = [
      { label: 'Início', routerLink: '/' },
      { label: 'Documentos', routerLink: 'documentos' },
      { label: 'Processos', routerLink: 'processos' },
    ];
  }
}
