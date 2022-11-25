/* Angular Imports */
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

/* PrimeNg Imports */
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { InputTextModule } from 'primeng/inputtext';
import { KeyFilterModule } from 'primeng/keyfilter';
import { MenubarModule } from 'primeng/menubar';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';

/* Own Imports */
import { DocumentoDetailComponent } from './components/documento/documento-detail/documento-detail.component';
import { DocumentoListComponent } from './components/documento/documento-list/documento-list.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProcessoDetailComponent } from './components/processo/processo-detail/processo-detail.component';
import { ProcessoListComponent } from './components/processo/processo-list/processo-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DocumentoDetailComponent,
    DocumentoListComponent,
    HomeComponent,
    NotFoundComponent,
    ProcessoDetailComponent,
    ProcessoListComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    ButtonModule,
    DropdownModule,
    FileUploadModule,
    FormsModule,
    HttpClientModule,
    InputTextModule,
    KeyFilterModule,
    MenubarModule,
    MessageModule,
    MessagesModule,
    RouterModule,
    TableModule,
    ToastModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
