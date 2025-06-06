unit str1;

  interface
    function alltrim(str:string):string;
    function opstr(str:string):string;
    function upstr(str:string):string;
    function pad(str:string;ch:char;dl,vid:byte):string;
    function StrH(X:byte;Full:boolean):string;

  implementation
    uses crt,dos;

{-------------------------------------------------------------------------}
{  �㭪�� alltrim  ������ ��ப� �� ���楢�� � ��砫��� �஡����      }
{-------------------------------------------------------------------------}
function alltrim(str:string):string;
  begin
    while (str[1]=' ')and(length(str)>0) do str:=copy(str,2,length(str)-1);
    while (str[length(str)]=' ')and(length(str)>0) do str:=copy(str,1,length(str)-1);
    alltrim:=str;
  end;

{-------------------------------------------------------------------------}
{  �㭪�� Opstr  ��p������ ��ப� � ������ ॣ���p                       }
{-------------------------------------------------------------------------}
  function opstr(str:string):string;
    var b1:byte;
    begin
      for b1:=1 to length(str) do begin {2}
        if str[b1] in ['A'..'Z'] then str[b1]:=chr(ord(str[b1])+32);
        if str[b1] in ['�'..'�'] then str[b1]:=chr(ord(str[b1])+32);
        if str[b1] in ['�'..'�'] then str[b1]:=chr(ord(str[b1])+80);
      end; {2}
      opstr:=str;
    end;

{-------------------------------------------------------------------------}
{  �㭪�� Upstr  ��p������ ��ப� � ��p孨� p�����p                      }
{-------------------------------------------------------------------------}
  function upstr(str:string):string;
    var b1:byte;
    begin
      for b1:=1 to length(str) do begin {2}
        if str[b1] in ['a'..'z'] then str[b1]:=chr(ord(str[b1])-32);
        if str[b1] in ['�'..'�'] then str[b1]:=chr(ord(str[b1])-32);
        if str[b1] in ['�'..'�'] then str[b1]:=chr(ord(str[b1])-80);
      end; {2}
      upstr:=str;
    end;


{-------------------------------------------------------------------------}
{  �㭪�� Pad  �������� ��ப� 㪠����� ᨬ�����                       }
{-------------------------------------------------------------------------}
function pad(str:string;ch:char;dl,vid:byte):string;
  begin
    while length(str)<dl do begin {2}
      case vid of {3}
      0: str:=str+ch;
      1: str:=ch+str;
      else str:=ch+str+ch;
      end; {3}
    end; {2}
    if (length(str)>dl) then str:=copy(str,1,length(str)-1);
    pad:=str;
  end;

{-------------------------------------------------------------------------}
{ ��᫮ -> ��ப� (� 16-�筮� ��⥬�), Full - ��������� �㫥�           }
{-------------------------------------------------------------------------}
Function StrH(X:byte;Full:boolean):string;
  Var r_s:string;
  Begin
    r_s:='';
    While X>0 do begin {2}
      If X mod 16 <=9 then
        r_s:=chr(X mod 16 +$30)+r_s
      else
        r_s:=chr(X mod 16 +$30+$27)+r_s;
      X:=X div 16;
    end; {2}
    If Full and (length(r_s)<2) then r_s:='0'+r_s;
    StrH:=r_s;
  End;


End.