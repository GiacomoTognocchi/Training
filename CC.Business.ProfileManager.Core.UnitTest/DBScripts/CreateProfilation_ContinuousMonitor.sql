DECLARE
  lUidProfileCR      cribiscom.ccpe_profiles.uidprofile%TYPE;
  lprofObjNS         cribiscom.ccpd_profilationobjnamespaces.codprofilationobjectnamespace%type;
  lUserFullName      cribiscom.ccpe_profilations.coduserfullname%type;
  lUidProfile        cribiscom.ccpe_profilations.uidprofile%TYPE;
BEGIN

  lUidProfile := hextoraw('417DBFA93291D3B9E05007D4A24C7A32');
  lprofObjNS      := 'urn:crif-cribiscom-continuousmonitor-2016-10-21';
  lUserFullName   := 'ES=1038,DS=1038,SB=878320000,OF=878500000,U=CODUSER_STD10';
  

insert into cribiscom.ccpe_profilations
  (uidprofilation,
   codgateway,
   codprofilationobjectnamespace,
   coduserfullname,
   uidprofile,
   lobxmloverride)
values
  (sys_guid(), 'A', lprofObjNS, lUserFullName, lUidProfile, null);

     

     
  COMMIT;
  
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END;
/
EXIT;
