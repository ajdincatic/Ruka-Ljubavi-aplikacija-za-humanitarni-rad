package com.fit.ba.rukaljubavi

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Spinner
import android.widget.Toast
import androidx.core.app.NotificationCompat
import com.fit.ba.rukaljubavi.Models.Grad
import com.fit.ba.rukaljubavi.Requests.BenefiktorInsertRequest
import com.fit.ba.rukaljubavi.Services.*
import kotlinx.android.synthetic.main.activity_registracija_benefiktor.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RegistracijaBenefiktorActivity : AppCompatActivity() {

    private val serviceGradovi = APIService.buildService(GradService::class.java)
    private val service = APIService.buildService(BenefiktorService::class.java)
    var benefiktor = BenefiktorInsertRequest()
    var gradovi: MutableList<Grad>? = arrayListOf(Grad(1,"test"),Grad(2,"teswwwwt"))

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_registracija_benefiktor)

        btnBack4.setOnClickListener {
            val intent = Intent(this,RegistracijaIzborActivity::class.java)
            startActivity(intent)
        }

        btnRegistracijaBenefiktorDalje.setOnClickListener {
            val intent = Intent(this,PDVBrojPotvrdaActivity::class.java)
            startActivity(intent)
            sendNoviBenefiktor()
        }

        getLokacije()
        var adapter = ArrayAdapter<Grad>(this,android.R.layout.simple_list_item_1,gradovi!!)
        spnBenLokacija.adapter = adapter
        spnBenLokacija.onItemSelectedListener = object : AdapterView.OnItemSelectedListener{
            override fun onNothingSelected(p0: AdapterView<*>?) {
            }

            override fun onItemSelected(p0: AdapterView<*>?, p1: View?, p2: Int, p3: Long) {
                var g = p0!!.getItemAtPosition(p2) as Grad
                benefiktor.mjestoPrebivalistaId = g.id
            }

        }
    }

    private fun getLokacije() {
        val requestCall = serviceGradovi.getAll()
        requestCall.enqueue(object : Callback<List<Grad>> {
            override fun onFailure(call: Call<List<Grad>>, t: Throwable) {
                Toast.makeText(this@RegistracijaBenefiktorActivity,"Server error", Toast.LENGTH_SHORT).show()
            }

            override fun onResponse(call: Call<List<Grad>>, response: Response<List<Grad>>) {
                if(response.isSuccessful){
                    var list = response.body()
                    gradovi = list!!.toMutableList()
                    Toast.makeText(this@RegistracijaBenefiktorActivity,"Pogrešno korisničko ime ili lozinka. Pokušajte ponovo.", Toast.LENGTH_SHORT).show()

                }
                else{
                    Toast.makeText(this@RegistracijaBenefiktorActivity,"Pogrešno korisničko ime ili lozinka. Pokušajte ponovo.", Toast.LENGTH_SHORT).show()
                }
            }
        })
    }

    private fun sendNoviBenefiktor() {
        benefiktor.nazivKompanije = txtRegNazivKompanije!!.text.toString()
        benefiktor.adresa = txtRegAdresa!!.text.toString()
        benefiktor.email = txtRegEmail!!.text.toString()
        benefiktor.password = txtRegPassword!!.text.toString()
        benefiktor.confirmPassword = txtRegPasswordPotvrda!!.text.toString()
        benefiktor.telefon = txtRegTelefon!!.text.toString()

        val intent = Intent(this, PDVBrojPotvrdaActivity::class.java)
        intent.putExtra("NEW_BENEFIKTOR",benefiktor)
        startActivity(intent)
    }
}