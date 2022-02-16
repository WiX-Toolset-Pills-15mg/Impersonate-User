:: ====================================================================================================
:: Step 4: Install the msi
:: ====================================================================================================
:: 
:: Make sure the custom action is configured with Impersonate="yes", build and install.
:: Look into the log file to see the user's rights.
:: 
:: Change the custom action's configuration to Impersonate="no", build and install.
:: Look into the log file to see the user's rights.

msiexec /i ImpersonateUser.msi /l*vx install.log