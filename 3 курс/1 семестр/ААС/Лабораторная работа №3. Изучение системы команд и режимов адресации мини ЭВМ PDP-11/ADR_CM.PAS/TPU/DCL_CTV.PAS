Unit Dcl_CTV;

Interface
const
     cmax=3;
     Mkd=8;  {max ���-�� ������}
     Mnp=5;   {max �᫮ �஢�७�� 1 �ਬ��}
     N_raz=8; {��饥 �-�� �ਬ�஢ � ࠧ����}
     fres ='files\Merite';
     mva:array[1..12] of string
          =('��ﬠ� �१ ॣ����        RN           ',
            '��ﬠ� � ���㢥��祭���    (RN)+        ',
            '��ﬠ� � ���㬥��襭���    -(RN)        ',
            '��������                  E(RN)        ',
            '��ᢥ���� �१ ॣ����     (RN) ��� @RN ',
            '��ᢥ���� � ���㢥��祭��� @(RN)+       ',
            '��ᢥ���� � ���㬥��襭��� @-(RN)       ',
            '��ᢥ���� ��������        @E(RN)       ',
            '�����।�⢥����            #E           ',
            '��᮫�⭠�                  @#E          ',
            '�⭮�⥫쭠�               E            ',
            '�⭮�⥫쭮-��ᢥ����      @E           ');
type
     t_res = record
            ident : string[24];
            mer   : array[1..12] of char;
            exit  : byte;
            dolg  : array[1..Mkd] of longint;
            kd    : byte;
            prim  : longint;
            razd  : byte;
            end;
var
   fo     : file of t_Res;
   res    : t_Res;
Implementation
end.
