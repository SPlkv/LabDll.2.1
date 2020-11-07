library Project2;

uses
  SysUtils,
  Classes;

{$R *.res}

Function f1(a:Integer;b:Integer):Integer; stdcall; export;

Begin
 Result:=2*a+2*b;
End;

Function f2(a:Double;b:Double):Double; cdecl; export;
Begin
 Result:=a*b;
End;

Exports
 f1  name 'func1',
 f2  name 'func2';

begin
end.
 