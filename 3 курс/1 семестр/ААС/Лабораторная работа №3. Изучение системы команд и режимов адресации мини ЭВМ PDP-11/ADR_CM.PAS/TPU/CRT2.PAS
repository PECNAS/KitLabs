unit crt2;

Interface

const
  video=$b800;
  ngKlKey=128;
  vgKlKey=159;
  KlKey:array[ngKlKey..vgKlKey] of byte=(
   33,51,
   32,22,38,20,39,25,48,16,19,37,
   47,21,36,34,35,46,49,18,30,26,
   17,45,23,24,41,31,50,40,52,44);
  rzd='|';

type
  tMKey=set of byte;
  tv_buf=array[0..50*160-1] of byte;
  tv_buf25=array[0..25*160-1] of byte;
  ptrtv_buf=^tv_buf;
Var
  v_buf:tv_buf absolute video:0;
{  ekr:ptrtv_buf;}
  frm:string;
  fScreen:file of tv_buf;

  Procedure Cur(On:Boolean);  { Вкл(TRUE) или Выкл(FALSE) курсор }
  Procedure CurSize(Size:byte); { Размер курсора 0..16           }
  Procedure Intensiv(Vkl:boolean);  { Интенсивность TRUE         }
  Procedure zapolnenie(k1,k2,k3,k4,sim1,atr1:byte);
  Procedure zapolnenie_a(k1,k2,k3,k4,atr:byte);
  Procedure zapolnenie_s(k1,k2,k3,k4,sim:byte);
  Procedure v_c(k1,k2:byte;str:string);
  Procedure v_ps(str:string;atr,vatr:byte);
  Procedure osk;

  Function ZagFont:string;
  Procedure VosstFont;
  Procedure ramka_f(k1,k2,k3,k4:byte);
  procedure v_l_f(k1,k2,vis:byte);
  procedure g_l_f(k1,k2,sh:byte);
  Function InvAtr(atr:byte):byte;


Implementation
  uses crt,dos,str1;


  Procedure Cur(On:Boolean);
    Var
      r:Registers;
    Begin
      r.AH:=$0f;
      intr($10,r);
      If r.AL<=3 then begin {2}
        If On then r.CH:=15
        else r.CH:=17;
        r.AH:=1;
        r.CL:=16;
        intr($10,r);
      end; {2}
    End;

  Procedure CurSize(Size:byte);
  Var
    r:Registers;
  Begin
    r.AH:=$0f;
    intr($10,r);
    If r.AL<=3 then begin {2}
      r.CH:=17-(Size mod 17);
      r.AH:=1;
      r.CL:=16;
      intr($10,r);
    end; {2}
  End;


  procedure Intensiv(Vkl:boolean);
    var r:Registers;
    Begin
      r.AH:=$10;
      r.AL:=3;
      r.BL:=1-byte(Ord(Vkl));
      intr($10,r);
    End;


{ Заполнение прямоуг.обл : 4 координаты , атр заполнения , симв заполнения }
  procedure zapolnenie(k1,k2,k3,k4,sim1,atr1:byte);
    var b1,b2:byte;
    begin
      for b1:=k1 to k3 do
        for b2:=k2 to k4 do begin {2}
          mem[video:(80*b1+b2)*2]:=sim1;
          mem[video:(80*b1+b2)*2+1]:=atr1;
        end; {2}
    end;
  procedure zapolnenie_a(k1,k2,k3,k4,atr:byte);
    var b1,b2:byte;
    begin
      for b1:=k1 to k3 do
        for b2:=k2 to k4 do
          mem[video:(80*b1+b2)*2+1]:=atr;
    end;

  procedure zapolnenie_s(k1,k2,k3,k4,sim:byte);
    var b1,b2:byte;
    begin
      for b1:=k1 to k3 do
        for b2:=k2 to k4 do
          mem[video:(80*b1+b2)*2]:=sim;
    end;

{-------------------------------------------------------------------------}
{  процедура v_c  вывод строки на экран в заданных координатах            }
{-------------------------------------------------------------------------}
  procedure v_c(k1,k2:byte;str:string);
    var b1:byte;
        w1:word;
    begin
      w1:=(80*k1+k2-1)*2;
      for b1:=1 to length(str) do
        mem[video:w1+b1*2]:=ord(str[b1]);
    end;

  procedure v_ps(str:string;atr,vatr:byte);
    Var k2:byte;
    begin
      k2:=0;
      zapolnenie(24,0,24,79,32,atr);
      vatr:=byte(atr and $f0 + vatr and $0f);
      while pos(rzd,str)>0 do begin {2}
        zapolnenie_a(24,k2,24,k2+pos(' ',str)-2,vatr);
        v_c(24,k2,copy(str,1,pos(rzd,str)-1));
        inc(k2,pos(rzd,str));
        str:=copy(str,pos(rzd,str)+1,length(str)-pos(rzd,str));
      end; {2}
    end;

  {-------------------------------------------------------------------------}
  {  процедура osk  очистить буфер клавиатуры                               }
  {-------------------------------------------------------------------------}
  procedure osk;
    begin
      while keypressed do if ord(readkey)=0 then if ord(readkey)=0 then ;
    end;

  Function ZagFont:string;
  Const
    Lines=16;
    KSimbols=15;
    Simbols:array[1..KSimbols,1..Lines] of byte =(
     ($0FF,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,
      $0C0,$0C0,$0C0,$0C0),
     ($0FF,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00),
     ($0FF,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01),
     ($01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01),
     ($01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$01,$0FF),
     ($00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$00,$0FF),
     ($0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,
      $0C0,$0C0,$0C0,$0C0,$0FF),
     ($0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,
      $0C0,$0C0,$0C0,$0C0,$0C0),
{9}  ($0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0C0,$0FF,$0C0,$0C0,$0C0,
      $0C0,$0C0,$0C0,$0C0,$0C0),
     ($01,$01,$01,$01,$01,$01,$01,$0FF,$01,$01,$01,
      $01,$01,$01,$01,$01),
     ($0FF,$18,$18,$18,$18,$18,$18,$18,$18,$18,$18,
      $18,$18,$18,$18,$18),
     ($18,$18,$18,$18,$18,$18,$18,$18,$18,$18,$18,
      $18,$18,$18,$18,$0FF),
     ($18,$18,$18,$18,$18,$18,$18,$0FF,$18,$18,$18,
      $18,$18,$18,$18,$18),
     ($00,$00,$00,$00,$00,$00,$00,$0FF,$00,$00,$00,
      $00,$00,$00,$00,$00),
     ($18,$18,$18,$18,$18,$18,$18,$18,$18,$18,$18,
      $18,$18,$18,$18,$18));
    Start=198;
    frm3=chr(Start)+chr(Start+1)+chr(Start+2)+chr(Start+3)+
     chr(Start+4)+chr(Start+5)+chr(Start+6)+chr(Start+7)+
     chr(Start+8)+chr(Start+9)+chr(Start+10)+chr(Start+11)+
     chr(Start+12)+chr(Start+13)+chr(Start+14);
  Var
    r:Registers;
  Begin
{    Вход:  AL = 0: загрузить шрифт для текстового режима (таблица для INT 44H)
                   ES:BP => таблица пользователя
                   CX = число записывамых символов
                   DX = смещение символа
                   BL = номер замещаемого блока (0 до 4 (7для VGA) )
                   BH = число байт на символ (обычно = 8)}
    r.AL:=0;
    r.ES:=Seg(Simbols);
    r.BP:=Ofs(Simbols);
    r.BH:=Lines;
    r.BL:=0;
    r.DX:=Start;
    r.CX:=Trunc(SizeOf(Simbols)/Lines);
    r.AH:=$11;
    intr($10,r);
    ZagFont:=frm3;
  End;

  Procedure VosstFont;
  Var
    r:Registers;
  Begin
{ ■VGA■     AL = 4: загрузить ROM 8x16 двойной точности символы
                   BL = номер замещаемого блока (0 до 7)}
    r.AL:=4;
    r.BL:=0;
    r.AH:=$11;
    intr($10,r);
  End;

  Procedure ramka_f(k1,k2,k3,k4:byte);
  Var b1:byte;
  begin
    While length(frm)<8 do frm:=frm+' ';
    For b1:=k2 to k4 do begin {2}
      mem[video:(k1*80+b1)*2]:=ord(frm[2]);
      mem[video:(k3*80+b1)*2]:=ord(frm[6]);
    End; {2}
    For b1:=k1 to k3 do begin {2}
      mem[video:(b1*80+k2)*2]:=ord(frm[8]);
      mem[video:(b1*80+k4)*2]:=ord(frm[4]);
    End; {2}
    mem[video:(k1*80+k2)*2]:=ord(frm[1]);
    mem[video:(k1*80+k4)*2]:=ord(frm[3]);
    mem[video:(k3*80+k4)*2]:=ord(frm[5]);
    mem[video:(k3*80+k2)*2]:=ord(frm[7]);
  end;

  procedure v_l_f(k1,k2,vis:byte);
    var b1:byte;
    Begin
      While length(frm)<15 do frm:=frm+' ';
      for b1:=k1+1 to k1+vis-1 do begin {2}
        If mem[video:(80*b1+k2)*2]=ord(frm[14]) then
          mem[video:(80*b1+k2)*2]:=ord(frm[13])
        else
          mem[video:(80*b1+k2)*2]:=ord(frm[15]);
      end; {2}
      mem[video:(80*k1+k2)*2]:=ord(frm[11]);
      mem[video:(80*(k1+vis)+k2)*2]:=ord(frm[12]);
    end; {1}

  procedure g_l_f(k1,k2,sh:byte);
    var b1,b2:byte;
    begin {1}
      While length(frm)<15 do frm:=frm+' ';
      for b1:=k2+1 to k2+sh-1 do begin {2}
        If mem[video:(80*k1+b1)*2]=ord(frm[15]) then
          mem[video:(80*k1+b1)*2]:=ord(frm[13])
        else
          mem[video:(80*k1+b1)*2]:=ord(frm[14]);
      end; {2}
      mem[video:(80*k1+k2)*2]:=ord(frm[9]);
      mem[video:(80*k1+k2+sh)*2]:=ord(frm[10]);
    end; {1}

  Function InvAtr(atr:byte):byte;
    Begin
      InvAtr:=byte(atr shr 4+ atr shl 4);
    End;




End.