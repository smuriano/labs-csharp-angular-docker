import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotFoundComponent } from './notfound.component';

describe('NotfoundComponent', () => {
  let component: NotFoundComponent;
  let fixture: ComponentFixture<NotFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NotFoundComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Deve criar o componente: Not Found', () => {
    expect(component).toBeTruthy();
  });

  it('Deve consta a mensagem: Página não encontrada', () => {
    const fixture = TestBed.createComponent(NotFoundComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.display-1').textContent).toEqual('Página não encontrada');
  });
});
