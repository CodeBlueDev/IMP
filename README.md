IMP - Inspect Memory of Process
===============================

Imp is an application/library that allows you to inspect the memory of 
a process.

## Overview

Imp allows the user to retrieve a list of running processes from the 
system. Once a process has been selected Imp shows the user the loaded 
modules used by the process. Imp will allow the user to unload a 
module or load in a module specified by the user. The name of the 
process can also be configured.

Imp accesses native Windows libraries using PInvoke - it is recommended 
to run Imp with Admin privileges to insure Imp has proper permissions. 

Imp will not be able to handle errors that occur when loading a third 
party library into an application. As of this time, Imp will not provide 
the ability to inject the CLR into a remote process if necessary.
