%echo on


SET src_folder=%2
SET src_com_folder=%3
SET tgt_folder=%4


if not exist %tgt_folder% mkdir %tgt_folder%

xcopy /Q /E /I /Y %src_folder% %tgt_folder%
xcopy /Q /E /I /Y %src_com_folder% %tgt_folder%




