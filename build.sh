mcs $(find . -name "*.cs") -reference:System.Drawing.dll -unsafe -out:a.exe

echo "WARNING - THIS BUILD WILL NOT WORK ON WINDOWS"