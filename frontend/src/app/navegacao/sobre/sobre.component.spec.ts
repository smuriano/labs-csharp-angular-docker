import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SobreComponent } from './sobre.component';

describe('SobreComponent', () => {
  let component: SobreComponent;
  let fixture: ComponentFixture<SobreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SobreComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SobreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Deve criar o componente: Sobre', () => {
    expect(component).toBeTruthy();
  });

  it('Deve consta a mensagem: Sidney Aparecido Muriano', () => {
    const fixture = TestBed.createComponent(SobreComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h1').textContent).toEqual('Sidney Aparecido Muriano');
  });
});
