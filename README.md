# ctpktool w/ patching #
Handles conversion to and from the CTPK image format used on the 3DS

#### Dumping CTPK  
To dump a .CTPK file with images converted to .PNG format:  
`ctpktool.exe x file.ctpk`  
or  
`ctpk.tool.exe x file.ctpk o output_folder`  

To dump a .CTPK file with raw image output data:  
`ctpktool.exe r file.ctpk`  
or  
`ctpk.tool.exe r file.ctpk o output_folder`  

#### Creating CTPK  
To create a .CTPK file from a folder (folder most contain .xml files generated while dumping):  
`ctpktool.exe c input_folder`  
or  
`ctpktool.exe c input_folder -o output.ctpk`  
  
### Creating CTPK with patch
`ctpktool.exe c input_folder p patch_folder`   
Inside the patch_folder folder, put files you want to **replace** from the input_folder. Putting the xml file in the patch_folder folder is optional.  
Point of this feature is so you don't have to copy the entire ctpk to compile a modified version of it.  
  
#### Credits  
**Normmatt** - For allowing me to use code from texturipper and answering questions about the format  
**Gericom** - Texture code from EveryFileExplorer (https://github.com/Gericom/EveryFileExplorer)  
