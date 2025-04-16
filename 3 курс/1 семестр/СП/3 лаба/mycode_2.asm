.model tiny
.code
org 100h
N:
    push cs
    pop ds 
    
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;  
    mov ah, 09h
    lea dx, prompt
    int 21h   
    
    mov ah, 0Ah
    lea dx, buffer
    int 21h    
    
    lea si, buffer + 2 
    lea di, message + 8 

c_name_loop:
    lodsb               
    cmp al, 0Dh        
    je fin_mes_label    
    stosb                
    jmp c_name_loop

fin_mes_label:
    lea si, rem_t 

add_text_loop:
    lodsb                   
    cmp al, '$'            
    je set_end_marker_label
    stosb                  
    jmp add_text_loop

set_end_marker_label:
    mov byte ptr [di], '$'
    mov ah, 09h
    lea dx, newline
    int 21h
     
    mov ah, 09h
    lea dx, message
    int 21h
    
    mov ax, 4C00h
    int 21h

.data
prompt db 'Vvedite vashu familiyu: $' 
buffer db 30, 0, 30 dup(0)           
newline db 0Dh, 0Ah, '$'              
message db 'Student ', 30 dup(0)    
rem_t db ' vse sdelal verno$', 0

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
end N
